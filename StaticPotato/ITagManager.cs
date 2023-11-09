namespace StaticPotato;

public interface ITagManager
{
    void Add(string tag, Page.Page page);
    void Clear();
    Task Generate();
}