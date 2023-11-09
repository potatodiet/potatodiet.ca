using StaticPotato.FileSystem;

namespace StaticPotato;

public class Website : IWebsite
{
    public Website(IFileSystem fileSystem, IHttpFileServer httpFileServer, ITagManager tagManager,
        IArchiveManager archiveManager)
    {
        FileSystem = fileSystem;
        HttpFileServer = httpFileServer;
        TagManager = tagManager;
        ArchiveManager = archiveManager;
    }

    private IFileSystem FileSystem { get; }
    private IHttpFileServer HttpFileServer { get; }
    private ITagManager TagManager { get; }
    private IArchiveManager ArchiveManager { get; }

    public async Task Watch(CancellationToken stoppingToken)
    {
        await Generate(false, stoppingToken);

        FileSystem.Watch(async () =>
        {
            Console.Clear();
            Console.WriteLine("Website generated.");
            await Generate(false, stoppingToken);
        });

        await HttpFileServer.Start(stoppingToken);
    }

    public async Task Generate(bool production, CancellationToken stoppingToken)
    {
        FileSystem.CleanPublic();
        TagManager.Clear();
        ArchiveManager.Clear();

        var template = await FileSystem.ReadText(BaseDirectory.Theme, "template.html");
        foreach (var file in FileSystem.List(BaseDirectory.Content))
        {
            stoppingToken.ThrowIfCancellationRequested();

            var page = new Page.Page
            {
                Path = file,
                Source = await FileSystem.ReadText(BaseDirectory.Content, file),
                TemplateText = template,
                CreationTime = FileSystem.CreationTime(BaseDirectory.Content, file),
                ModifiedTime = FileSystem.ModifiedTime(BaseDirectory.Content, file) ?? DateTime.UnixEpoch
            };
            page.Parse();

            if (production && page.Attributes?.Published is false) continue;

            if (page.Attributes?.Tags.Count == 0 && page.Attributes?.Title != "Home")
                Console.WriteLine($"{file} should have at least one tag.");

            foreach (var tag in page.Attributes?.Tags ?? Enumerable.Empty<string>()) TagManager.Add(tag, page);

            if (page.Attributes?.Title != "Home") ArchiveManager.Add(page);

            var outDir = page.Attributes?.Title == "Home" ? "/" : Path.GetFileNameWithoutExtension(file);
            var outFile = Path.Join(outDir, "index.html");
            await FileSystem.WriteText(BaseDirectory.Public, outFile, page.ToHtml());
        }

        await TagManager.Generate();
        await ArchiveManager.Generate();

        foreach (var file in FileSystem.List(BaseDirectory.Static)) FileSystem.CopyToPublic(BaseDirectory.Static, file);
        foreach (var file in FileSystem.List(BaseDirectory.Assets)) FileSystem.CopyToPublic(BaseDirectory.Assets, file);
    }
}