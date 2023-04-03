using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Emerson.Cargo.DataPipelines.Infrastructure;
using Emerson.Cargo.DataPipelines.Core;
using Emerson.Cargo.DataPipelines.Ingest;
using Microsoft.Extensions.Logging;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddCoreServices();
        services.AddInfrastructureServices();
        services.AddTransient<JsonDataProcessor>();
    }).ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .Build();

// path passed via args
var outFile = args.Length > 0? args.First() :  "output.json";

await ProcessDataFiles(host.Services, outFile);

Console.WriteLine();
Console.WriteLine($"------ Files are processed and updates stored in '{outFile}' ------");
Console.WriteLine();

await host.RunAsync();

static async Task ProcessDataFiles(IServiceProvider hostProvider, string outFile)
{
    using var serviceScope = hostProvider.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var processor = provider.GetRequiredService<JsonDataProcessor>();

    var filePath1 = @"Data/DeviceDataFoo1.json";
    var filePath2 = @"Data/DeviceDataFoo2.json";

    await processor.Run(new[] { filePath1, filePath2 }, outFile);
}