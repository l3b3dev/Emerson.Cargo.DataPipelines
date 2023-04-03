using MediatR;

namespace Emerson.Cargo.DataPipelines.Core.Features.DeviceData.Sensors;

public class Company2Query : IRequest<IEnumerable<Domain.Entities.DeviceData>>
{
    public Company2Query(string sensorData)
    {
        SensorData = sensorData;
    }

    public string SensorData { get; set; }
}