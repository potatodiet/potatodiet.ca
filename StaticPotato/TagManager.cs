using Markdig;
using Scriban;
using Scriban.Runtime;
using StaticPotato.FileSystem;

namespace StaticPotato;

public class TagManager : ITagManager
{
    private Dictionary<string, ISet<Page.Page>> Tags { get; } = new();
    private IFileSystem FileSystem { get; }

    public TagManager(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void Add(string tag, Page.Page page)
    {
        if (!Tags.ContainsKey(tag))
        {
            Tags[tag] = new SortedSet<Page.Page>(Comparer<Page.Page>.Create((a, b) => b.CreationTime.CompareTo(a.CreationTime)));
        }
        Tags[tag].Add(page);
    }

    public void Clear()
    {
        Tags.Clear();
    }

    public async Task Generate()
    {
        var tags = new List<(string Name, int Count)>();
        foreach (var (name, pages) in Tags)
        {
            tags.Add((name, pages.Count));
            await GenerateTag(name, pages);
        }
        tags.Sort((x, y) => y.Count.CompareTo(x.Count));
        
        var tagsText = await FileSystem.ReadText(BaseDirectory.Theme, "tags.html");
        var tagsTemplate = Template.Parse(tagsText);
        var tagsResult = await tagsTemplate.RenderAsync(new { Tags = tags });
        await FileSystem.WriteText(BaseDirectory.Public, "tags/index.html", tagsResult);
    }

    private async Task GenerateTag(string name, ISet<Page.Page> pages)
    {
        var splitPages = new List<(int Year, List<(string Month, List<Page.Page> Pages)>)>();
        Page.Page? prev = null;
        foreach (var page in pages)
        {
            if (prev?.CreationTime.Year != page.CreationTime.Year)
            {
                splitPages.Add((page.CreationTime.Year, new List<(string, List<Page.Page>)>()));
            }
            if (prev?.CreationTime.Month != page.CreationTime.Month)
            {
                splitPages.Last().Item2.Add((page.CreationTime.ToString("MMMM"), new List<Page.Page>()));
            }
            splitPages.Last().Item2.Last().Item2.Add(page);
            prev = page;
        }
        
        var text = await FileSystem.ReadText(BaseDirectory.Theme, "tag.html");
        var template = Template.Parse(text);
        var result = await template.RenderAsync(new { Tag = name, Pages = splitPages });
        await FileSystem.WriteText(BaseDirectory.Public, $"tags/{name.ToLower()}/index.html", result);
    }
}