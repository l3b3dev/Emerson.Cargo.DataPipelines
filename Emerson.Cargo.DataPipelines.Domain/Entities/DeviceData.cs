namespace Emerson.Cargo.DataPipelines.Domain.Entities;

public record struct DeviceData(int CompanyId, string CompanyName, int? DeviceId, string DeviceName, DateTime? FirstReadingDtm, DateTime? LastReadingDtm, int? TemperatureCount, double? AverageTemperature, int? HumidityCount, double? AverageHumdity);
