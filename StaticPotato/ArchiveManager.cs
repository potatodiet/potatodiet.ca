using Scriban;
using StaticPotato.FileSystem;

namespace StaticPotato;

public class ArchiveManager : IArchiveManager
{
    private SortedSet<Page.Page> Pages { get; } = new(Comparer<Page.Page>.Create((a, b) => b.CreationTime.CompareTo(a.CreationTime)));
    private IFileSystem FileSystem { get; }

    public ArchiveManager(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }
        
    public void Add(Page.Page page)
    {
        Pages.Add(page);
    }

    public void Clear()
    {
        Pages.Clear();
    }

    public async Task Generate()
    {
        var pages = new List<(int Year, List<(string Month, List<Page.Page> Pages)>)>();
        Page.Page? prev = null;
        foreach (var page in Pages)
        {
            if (prev?.CreationTime.Year != page.CreationTime.Year)
            {
                pages.Add((page.CreationTime.Year, new List<(string, List<Page.Page>)>()));
            }
            if (prev?.CreationTime.Month != page.CreationTime.Month)
            {
                pages.Last().Item2.Add((page.CreationTime.ToString("MMMM"), new List<Page.Page>()));
            }
            pages.Last().Item2.Last().Item2.Add(page);
            prev = page;
        }
            
        var text = await FileSystem.ReadText(BaseDirectory.Theme, "archive.html");
        var template = Template.Parse(text);
        var result = await template.RenderAsync(new { Pages = pages });
        await FileSystem.WriteText(BaseDirectory.Public, "archive/index.html", result);
    }
}