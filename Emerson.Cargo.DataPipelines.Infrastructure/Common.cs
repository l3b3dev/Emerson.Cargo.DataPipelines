using Emerson.Cargo.DataPipelines.Domain.Entities;

namespace Emerson.Cargo.DataPipelines.Infrastructure;

public static class Common
{
    public static SensorType ParseSensorType(string? sensorType) => sensorType switch
    {
        "TEMP" => SensorType.Temperature,
        "Temperature" => SensorType.Temperature,
        "HUM" => SensorType.Humidity,
        "Humidty" => SensorType.Humidity,

        _ => throw new ArgumentOutOfRangeException(nameof(sensorType), $"Not expected sensor value: {sensorType}"),
    };
}