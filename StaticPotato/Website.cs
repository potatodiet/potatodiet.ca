using StaticPotato.FileSystem;

namespace StaticPotato;

public class Website : IWebsite
{
    public Website(IFileSystem fileSystem, IHttpFileServer httpFileServer)
    {
        FileSystem = fileSystem;
        HttpFileServer = httpFileServer;
    }

    private IFileSystem FileSystem { get; }
    private IHttpFileServer HttpFileServer { get; }

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

            var outDir = page.Attributes?.Title == "Home" ? "/" : Path.GetFileNameWithoutExtension(file);
            var outFile = Path.Join(outDir, "index.html");
            await FileSystem.WriteText(BaseDirectory.Public, outFile, page.ToHtml());
        }

        foreach (var file in FileSystem.List(BaseDirectory.Static)) FileSystem.CopyToPublic(BaseDirectory.Static, file);
        foreach (var file in FileSystem.List(BaseDirectory.Assets)) FileSystem.CopyToPublic(BaseDirectory.Assets, file);
    }
}