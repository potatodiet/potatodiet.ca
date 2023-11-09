using System.Text.RegularExpressions;
using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using Scriban;
using StaticPotato.Page.Extended;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace StaticPotato.Page;

public partial class Page
{
    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseYamlFrontMatter().Build();
    private static readonly IDeserializer Deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
    [GeneratedRegex(@"(<table>.*?</table>)", RegexOptions.Singleline | RegexOptions.RightToLeft)]
    private static partial Regex TableOverflowRx();
    private MarkdownDocument Document => Markdown.Parse(Source, Pipeline);
    public required string Path { get; set; }
    public required string Source { get; set; }
    public required string TemplateText { get; set; }
    public required DateTime CreationTime { get; set; }
    public required DateTime ModifiedTime { get; set; }
    public PageAttributes? Attributes { get; set; }

    public void Parse()
    {
        Attributes = ParseAttributes();
    }

    public string ToHtml()
    {
        if (Attributes?.Extended is not null)
        {
            var type = Type.GetType($"StaticPotato.Page.Extended.{Attributes.Extended}");
            if (type is null)
            {
                throw new Exception($"StaticPotato.Page.Extended.{Attributes.Extended} isn't a valid class");
            }
            
            var extendedPage = (IExtendedPage)Activator.CreateInstance(type)!;
            Source = extendedPage.Parse(Source);
        }
        
        var fragment = Document.ToHtml(Pipeline);
        fragment = TableOverflowRx().Replace(fragment, "<div class=\"table-wrapper\">$1</div>");
        var template = Template.Parse(TemplateText);
        
        return template.Render(new
        {
            Content = fragment,
            Title = Attributes?.Title,
            CreationTime = CreationTime.ToString("d MMMM yyyy"),
            ModifiedTime = ModifiedTime.ToString("d MMMM yyyy"),
            Tags = Attributes?.Tags
        });
    }

    private PageAttributes ParseAttributes()
    {
        var block = Document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();
        if (block is null)
        {
            throw new Exception("Each page much contain a YAML frontmatter.");
        } 
        
        var frontmatter = Source.Substring(block.Span.Start, block.Span.Length);
        var yaml = frontmatter.Replace("---", "");
        return Deserializer.Deserialize<PageAttributes>(yaml.TrimStart());
    }

    public string Url => $"/{Path.Replace(".md", "/")}";

    public override bool Equals(object? obj) => GetHashCode() == obj?.GetHashCode();
    public override int GetHashCode() => Url.GetHashCode();
}