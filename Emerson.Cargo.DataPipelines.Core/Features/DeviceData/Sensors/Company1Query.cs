using MediatR;

namespace Emerson.Cargo.DataPipelines.Core.Features.DeviceData.Sensors;

public class Company1Query : IRequest<IEnumerable<Domain.Entities.DeviceData>>
{
    public Company1Query(string sensorData)
    {
        SensorData = sensorData;
    }

    public string SensorData { get; set; }

}