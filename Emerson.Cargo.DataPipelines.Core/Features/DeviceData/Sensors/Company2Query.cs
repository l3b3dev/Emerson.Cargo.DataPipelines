using MediatR;

namespace Emerson.Cargo.DataPipelines.Core.Features.DeviceData.Sensors;

/// <summary>
/// Mediator Company2 Query
/// </summary>
public class Company2Query : IRequest<IEnumerable<Domain.Entities.DeviceData>>
{
    public Company2Query(string sensorData)
    {
        SensorData = sensorData;
    }

    /// <summary>
    /// JSON String data from sensor
    /// </summary>
    public string SensorData { get; set; }
}