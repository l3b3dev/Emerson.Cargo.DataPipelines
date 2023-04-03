using Emerson.Cargo.DataPipelines.Domain.Entities;

namespace Emerson.Cargo.DataPipelines.Core.Contracts;

public interface ISensorDataParser
{
    IEnumerable<DeviceData> Parse(string sensorData);
}