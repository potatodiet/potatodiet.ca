namespace StaticPotato;

public interface IWebsite
{
    Task Watch(CancellationToken stoppingToken);
    Task Generate(bool production, CancellationToken stoppingToken);
}