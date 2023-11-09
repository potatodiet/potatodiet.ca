namespace StaticPotato;

public interface IArchiveManager
{
    void Add(Page.Page page);
    void Clear();
    Task Generate();
}