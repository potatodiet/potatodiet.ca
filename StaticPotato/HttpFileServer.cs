using System.Net;
using StaticPotato.FileSystem;

namespace StaticPotato;

public class HttpFileServer : IHttpFileServer
{
    private static Dictionary<string, string> ContentTypes { get; } = new()
    {
        { ".html", "text/html" },
        { ".css", "text/css" }
    };
    private HttpListener Listener { get; } = new();
    private IFileSystem FileSystem { get; }

    public HttpFileServer(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
        Listener.Prefixes.Add("http://localhost:8000/");
    }

    public async Task Start(CancellationToken stoppingToken)
    {
        Listener.Start();
        Console.WriteLine("Server started at http://localhost:8000/");

        while (true)
        {
            var context = await Listener.GetContextAsync().WaitAsync(stoppingToken);
            var path = context.Request.Url?.LocalPath;
            if (path is null)
            {
                break;
            }

            if (path.Last() == '/')
            {
                path += "index.html";
            }

            var ext = Path.GetExtension(path);
            context.Response.ContentType = ContentTypes.GetValueOrDefault(ext);

            try
            {
                await FileSystem.ReadFs(BaseDirectory.Public, path).CopyToAsync(context.Response.OutputStream);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 404;
            }
            finally
            {
                context.Response.Close();
            }
        }
    }
}