namespace Emerson.Cargo.DataPipelines.Domain.Entities;

public record struct SensorData(int SensorId, string SensorName, SensorType Type, DateTime CaptureDate, double SensorReading);