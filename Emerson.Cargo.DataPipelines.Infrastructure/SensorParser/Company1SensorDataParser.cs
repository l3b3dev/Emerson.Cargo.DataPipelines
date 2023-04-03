using Emerson.Cargo.DataPipelines.Core.Contracts;
using Emerson.Cargo.DataPipelines.Domain.Entities;
using System.Text.Json;

namespace Emerson.Cargo.DataPipelines.Infrastructure.SensorParser;

public class Company1SensorDataParser : ICompany1SensorDataParser
{
    public IEnumerable<DeviceData> Parse(string sensorData)
    {
        using var jsonDoc = JsonDocument.Parse(sensorData);

        var root = jsonDoc.RootElement;

        var companyId = root.GetProperty("PartnerId").GetInt32(); // Foo1: PartnerId, Foo2: CompanyId
        var companyName = root.GetProperty("PartnerName").GetString(); // Foo1: PartnerName, Foo2: Company


        //enumerating Trackers from Foo1
        var sensorDataQuery = from tracker in root.GetProperty("Trackers").EnumerateArray()
            let deviceId = tracker.GetProperty("Id").GetInt32()
            let deviceName = tracker.GetProperty("Model").GetString()
            select from sensor in tracker.GetProperty("Sensors").EnumerateArray()
                let sensorType = Common.ParseSensorType(sensor.GetProperty("Name").GetString())
                select sensor.GetProperty("Crumbs").EnumerateArray().Select(cData =>
                    new SensorData(deviceId, deviceName, sensorType,
                        DateTime.Parse(cData.GetProperty("CreatedDtm").GetString() ??
                                       throw new ArgumentException("Sensor with invalid capture date")),
                        cData.GetProperty("Value").GetDouble()
                    ));


        var groupBySensorQuery =
            from queryData in sensorDataQuery.SelectMany(d => d.SelectMany(sd => sd))
            group queryData by new { queryData.SensorId, queryData.SensorName }
            into sensorGroup
            let tempReadings = sensorGroup.Where(sd => sd.Type == SensorType.Temperature)
            let humidityReadings = sensorGroup.Where(sd => sd.Type == SensorType.Humidity)
            select new DeviceData(companyId, companyName, sensorGroup.Key.SensorId, sensorGroup.Key.SensorName,
                sensorGroup.Min(c => c.CaptureDate), sensorGroup.Max(c => c.CaptureDate), tempReadings.Count(),
                tempReadings.Average(tr => tr.SensorReading),
                humidityReadings.Count(), humidityReadings.Average(hr => hr.SensorReading));

        return groupBySensorQuery.ToList();
    }
}