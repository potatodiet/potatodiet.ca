using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using StaticPotato.FileSystem;

namespace StaticPotato.Remote;

public class R2Remote : IRemote
{
    private IFileSystem FileSystem { get; }
    private IAmazonS3 S3Client { get; }
    private HttpClient HttpClient { get; }
    private IConfiguration Configuration { get; }

    public R2Remote(IFileSystem fileSystem, IAmazonS3 s3Client, HttpClient httpClient, IConfiguration configuration)
    {
        FileSystem = fileSystem;
        S3Client = s3Client;
        HttpClient = httpClient;
        Configuration = configuration;
    }
    
    public async Task Sync(CancellationToken cancellationToken)
    {
        var entries = FileSystem.List(BaseDirectory.Public);
        foreach (var entry in entries)
        {
            var fs = FileSystem.ReadFs(BaseDirectory.Public, entry);
            var response = await S3Client.PutObjectAsync(new PutObjectRequest()
            {
                BucketName = Configuration.GetSection("Remote:BucketName").Value,
                InputStream = fs,
                Key = entry,
                DisablePayloadSigning = true // https://community.cloudflare.com/t/putobjectasync-not-working-for-r2-with-aws-s3-net-sdk/427335/3
            }, cancellationToken);
        }

        var zone = Configuration.GetSection("Remote:Zone").Value;
        var token = Configuration.GetSection("Remote:Token").Value;

        using var request =
            new HttpRequestMessage(HttpMethod.Post, $"https://api.cloudflare.com/client/v4/zones/{zone}/purge_cache");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Content = new StringContent("{\"purge_everything\":true}")
        {
            Headers = { ContentType = new MediaTypeWithQualityHeaderValue("application/json") }
        };

        var httpResponse = await HttpClient.SendAsync(request, cancellationToken);
        if (!httpResponse.IsSuccessStatusCode)
        {
            await Console.Error.WriteLineAsync(await httpResponse.Content.ReadAsStringAsync(cancellationToken));
            throw new Exception("Failed to refresh Cloudflare's cache.");
        }
    }
}