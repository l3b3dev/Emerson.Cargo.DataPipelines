using Emerson.Cargo.DataPipelines.Domain.Entities;
using MediatR;
using Emerson.Cargo.DataPipelines.Core.Features.DeviceData.Sensors;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Emerson.Cargo.DataPipelines.Ingest;

internal sealed class JsonDataProcessor
{
    private readonly IMediator _mediator;
    private readonly ILogger<JsonDataProcessor> _logger;
    private readonly List<DeviceData> _deviceData = new();

    public JsonDataProcessor(IMediator mediator, ILogger<JsonDataProcessor> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public async Task Run(IEnumerable<string> dataFiles, string destination)
    {
        var hasData = false;

        // simulate ingestion of 
        foreach (var fp in dataFiles)
        {
            using var reader = File.OpenText(fp);
            var jsonData = await reader.ReadToEndAsync();

            using var jsonDoc = JsonDocument.Parse(jsonData);
            var root = jsonDoc.RootElement;
            // dynamically determine which company to use based on the json data
            var companyId = root.TryGetProperty("PartnerId", out var jsCompanyId) ? jsCompanyId.GetInt32() : root.GetProperty("CompanyId").GetInt32(); // Foo1: PartnerId, Foo2: CompanyId


            // route processing based on company id
            switch (companyId)
            {
                case 1:
                    var getCompany1DataQuery = new Company1Query(jsonData);

                    try
                    {
                        var company1Result = await _mediator.Send(getCompany1DataQuery);

                        _deviceData.AddRange(company1Result);
                        hasData = true;
                    }
                    catch (ArgumentException)
                    {
                        _logger.LogCritical("Invalid company 2 data");
                    }

                    break;
                case 2:
                    var getCompany2DataQuery = new Company2Query(jsonData);

                    try
                    {
                        var company2Result = await _mediator.Send(getCompany2DataQuery);

                        _deviceData.AddRange(company2Result);
                        hasData = true;
                    }
                    catch (ArgumentException)
                    {
                        _logger.LogCritical("Invalid company 2 data");
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid company id");
            }
        }

        //Serialize a list
        if (hasData)
        {
            var jsonList = JsonSerializer.Serialize(_deviceData, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            await File.WriteAllTextAsync(destination, jsonList);
        }
     
    }
}