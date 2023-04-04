using Emerson.Cargo.DataPipelines.Domain.Entities;

namespace Emerson.Cargo.DataPipelines.Infrastructure;

public static class Common
{
    /// <summary>
    /// Helper function for parsing sensor type since schemas are not consistent.
    /// Can be similarly extended to support other types
    /// </summary>
    /// <param name="sensorType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static SensorType ParseSensorType(string? sensorType) => sensorType switch
    {
        "TEMP" => SensorType.Temperature,
        "Temperature" => SensorType.Temperature,
        "HUM" => SensorType.Humidity,
        "Humidty" => SensorType.Humidity,

        _ => throw new ArgumentOutOfRangeException(nameof(sensorType), $"Not expected sensor value: {sensorType}"),
    };
}