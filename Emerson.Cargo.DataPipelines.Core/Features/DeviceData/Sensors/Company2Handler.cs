using Emerson.Cargo.DataPipelines.Core.Contracts;
using MediatR;

namespace Emerson.Cargo.DataPipelines.Core.Features.DeviceData.Sensors;

public class Company2Handler : IRequestHandler<Company2Query, IEnumerable<Domain.Entities.DeviceData>>
{
    private readonly ICompany2SensorDataParser _sensorParser;

    public Company2Handler(ICompany2SensorDataParser sensorParser)
    {
        _sensorParser = sensorParser;
    }

    public Task<IEnumerable<Domain.Entities.DeviceData>> Handle(Company2Query request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_sensorParser.Parse(request.SensorData));
    }
}