using LibGit2Sharp;
using Microsoft.Extensions.Configuration;

namespace StaticPotato.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private static FileSystemWatcher? ContentWatcher { get; set; }
    private static FileSystemWatcher? ThemeWatcher { get; set; }
    private string Root => Configuration.GetSection("Root").Value!;
    private IConfiguration Configuration { get; }

    public LocalFileSystem(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    private string RealPath(BaseDirectory baseDirectory, string path)
    {
        return Path.Join(BaseDirectoryToPath(baseDirectory), path);
    }

    public async Task<string> ReadText(BaseDirectory baseDirectory, string path)
    {
        path = RealPath(baseDirectory, path);
        return await File.ReadAllTextAsync(path);
    }
    
    public async Task WriteText(BaseDirectory baseDirectory, string path, string body)
    {
        path = RealPath(baseDirectory, path);
        
        var directory = Path.GetDirectoryName(path);
        if (directory is not null)
        {
            Directory.CreateDirectory(directory);
        }

        await File.WriteAllTextAsync(path, body);
    }

    public FileStream ReadFs(BaseDirectory baseDirectory, string path)
    {
        path = RealPath(baseDirectory, path);
        return File.OpenRead(path);
    }

    public DateTime CreationTime(BaseDirectory baseDirectory, string path)
    {
        path = RealPath(baseDirectory, path);
        return File.GetCreationTimeUtc(path);
    }

    public DateTime? ModifiedTime(BaseDirectory baseDirectory, string path)
    {
        path = RealPath(baseDirectory, path);
        return File.GetLastWriteTimeUtc(path);
        //using var repo = new Repository(Root);
        //path = RealPath(baseDirectory, path);
        //return repo.Commits.QueryBy(path).FirstOrDefault()?.Commit.Committer.When.UtcDateTime;
    }

    public IEnumerable<string> List(BaseDirectory baseDirectory)
    {
        var path = BaseDirectoryToPath(baseDirectory);
        return from file in Directory.GetFiles(path, "*", SearchOption.AllDirectories) 
            select file.Replace(path + "/", "");
    }

    public void CopyToPublic(BaseDirectory baseDirectory, string path)
    {
        var src = RealPath(baseDirectory, path);
        var dst = RealPath(BaseDirectory.Public, path);
        File.Copy(src, dst);
    }

    public void CleanPublic()
    {
        var path = BaseDirectoryToPath(BaseDirectory.Public);
        Directory.CreateDirectory(path);
        Directory.Delete(path, true);
        Directory.CreateDirectory(path);
    }

    public void Watch(Func<Task> callback)
    {
        ContentWatcher?.Dispose();
        ThemeWatcher?.Dispose();
        
        ContentWatcher = new FileSystemWatcher(BaseDirectoryToPath(BaseDirectory.Content))
        {
            IncludeSubdirectories = true,
            EnableRaisingEvents = true
        };
        ThemeWatcher = new FileSystemWatcher(BaseDirectoryToPath(BaseDirectory.Theme))
        {
            IncludeSubdirectories = true,
            EnableRaisingEvents = true
        };
        
        ContentWatcher.Changed += (object sender, FileSystemEventArgs e) => callback();
        ThemeWatcher.Changed += (object sender, FileSystemEventArgs e) => callback();
    }

    private string BaseDirectoryToPath(BaseDirectory baseDirectory)
    {
        return baseDirectory switch
        {
            BaseDirectory.Public => Path.Join(Root, "public"),
            BaseDirectory.Content => Path.Join(Root, "content"),
            BaseDirectory.Static => Path.Join(Root, "static"),
            BaseDirectory.Theme => Path.Join(Root, "theme"),
            BaseDirectory.Assets => Path.Join(Root, "theme", "assets"),
            _ => throw new InvalidOperationException()
        };
    }
}