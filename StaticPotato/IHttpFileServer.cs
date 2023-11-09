namespace StaticPotato;

public interface IHttpFileServer
{
    Task Start(CancellationToken stoppingToken);
}