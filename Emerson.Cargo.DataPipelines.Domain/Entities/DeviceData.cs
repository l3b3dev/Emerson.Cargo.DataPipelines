namespace Emerson.Cargo.DataPipelines.Domain.Entities;

/// <summary>
/// Represents summary of data for a device
/// The structure is specified in the requirements
/// </summary>
/// <param name="CompanyId"></param>
/// <param name="CompanyName"></param>
/// <param name="DeviceId"></param>
/// <param name="DeviceName"></param>
/// <param name="FirstReadingDtm"></param>
/// <param name="LastReadingDtm"></param>
/// <param name="TemperatureCount"></param>
/// <param name="AverageTemperature"></param>
/// <param name="HumidityCount"></param>
/// <param name="AverageHumdity"></param>
public record struct DeviceData(int CompanyId, string CompanyName, int? DeviceId, string DeviceName, DateTime? FirstReadingDtm, DateTime? LastReadingDtm, int? TemperatureCount, double? AverageTemperature, int? HumidityCount, double? AverageHumdity);
