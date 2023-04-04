using Emerson.Cargo.DataPipelines.Core.Contracts;
using MediatR;

namespace Emerson.Cargo.DataPipelines.Core.Features.DeviceData.Sensors;

/// <summary>
/// Mediator Company1 Handler
/// </summary>
public class Company1Handler : IRequestHandler<Company1Query, IEnumerable<Domain.Entities.DeviceData>>
{
    private readonly ICompany1SensorDataParser _sensorParser;

    public Company1Handler(ICompany1SensorDataParser sensorParser)
    {
        _sensorParser = sensorParser;
    }

    public Task<IEnumerable<Domain.Entities.DeviceData>> Handle(Company1Query request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_sensorParser.Parse(request.SensorData));
    }

}