using Emerson.Cargo.DataPipelines.Domain.Entities;

namespace Emerson.Cargo.DataPipelines.Core.Contracts;

/// <summary>
/// Main interface for parsing sensor data
/// </summary>
public interface ISensorDataParser
{
    IEnumerable<DeviceData> Parse(string sensorData);
}