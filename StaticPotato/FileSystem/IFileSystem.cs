namespace StaticPotato.FileSystem;

public interface IFileSystem
{
    Task<string> ReadText(BaseDirectory baseDirectory, string path);
    Task WriteText(BaseDirectory baseDirectory, string path, string body);
    FileStream ReadFs(BaseDirectory baseDirectory, string path);
    DateTime CreationTime(BaseDirectory baseDirectory, string path);
    DateTime? ModifiedTime(BaseDirectory baseDirectory, string path);
    IEnumerable<string> List(BaseDirectory baseDirectory);
    void CopyToPublic(BaseDirectory baseDirectory, string path);
    void CleanPublic();

    void Watch(Func<Task> callback);
}