using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StaticPotato;
using StaticPotato.FileSystem;
using StaticPotato.Remote;

var builder = Host.CreateApplicationBuilder();
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddHostedService<BackgroundWorker>();
builder.Services.AddScoped<IFileSystem, LocalFileSystem>();
builder.Services.AddScoped<IWebsite, Website>();
builder.Services.AddScoped<IHttpFileServer, HttpFileServer>();
builder.Services.AddScoped<IRemote, R2Remote>();
builder.Services.AddScoped<HttpClient, HttpClient>();

var awsOptions = new AWSOptions
{
    Credentials = new BasicAWSCredentials(
        builder.Configuration.GetSection("Remote:AccessKey").Value,
        builder.Configuration.GetSection("Remote:SecretKey").Value),
    DefaultClientConfig =
    {
        ServiceURL = builder.Configuration.GetSection("Remote:ServiceUrl").Value
    }
};
builder.Services.AddDefaultAWSOptions(awsOptions);

var host = builder.Build();
host.Run();