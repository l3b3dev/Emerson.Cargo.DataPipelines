using Emerson.Cargo.DataPipelines.Core.Contracts;
using Emerson.Cargo.DataPipelines.Infrastructure.SensorParser;
using Microsoft.Extensions.DependencyInjection;

namespace Emerson.Cargo.DataPipelines.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICompany1SensorDataParser, Company1SensorDataParser>();
        services.AddScoped<ICompany2SensorDataParser, Company2SensorDataParser>();

        return services;
    }
}