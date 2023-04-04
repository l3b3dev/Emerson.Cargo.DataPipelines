using MediatR;

namespace Emerson.Cargo.DataPipelines.Core.Features.DeviceData.Sensors;

/// <summary>
/// Mediator Company1 Query
/// </summary>
public class Company1Query : IRequest<IEnumerable<Domain.Entities.DeviceData>>
{
    public Company1Query(string sensorData)
    {
        SensorData = sensorData;
    }

    /// <summary>
    /// JSON String data from sensor
    /// </summary>
    public string SensorData { get; set; }

}