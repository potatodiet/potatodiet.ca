namespace StaticPotato.Remote;

public interface IRemote
{
    Task Sync(CancellationToken cancellationToken);
}