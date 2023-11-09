using Microsoft.Extensions.Hosting;
using StaticPotato.Remote;

namespace StaticPotato;

public class BackgroundWorker : BackgroundService
{
    public BackgroundWorker(IWebsite website, IRemote remote)
    {
        Website = website;
        Remote = remote;
    }

    private IWebsite Website { get; }
    private IRemote Remote { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var args = Environment.GetCommandLineArgs();
        switch (args[1])
        {
            case "watch":
                await Website.Watch(stoppingToken);
                break;
            case "sync":
                await Website.Generate(true, stoppingToken);
                await Remote.Sync(stoppingToken);
                break;
        }

        Environment.Exit(0);
    }
}