using Emerson.Cargo.DataPipelines.Core.Contracts;
using Emerson.Cargo.DataPipelines.Domain.Entities;
using Moq;

namespace Emerson.Cargo.DataPipelines.Core.UnitTests.Mocks;

public class SensorDataMocks
{
    public static List<DeviceData> SensorList = new()
    {
        new DeviceData(1,"XYZ",1, "D1", DateTime.Parse("01-30-2022 8:11"), DateTime.Parse("01-30-2022 10:11"), 1, 11.11, 1, 12.11),
        new DeviceData(2,"XYB",1, "D2", DateTime.Parse("01-27-2022 8:01"), DateTime.Parse("01-27-2022 11:31"), 1, 21.11, 1, 16.11),
    };

    public static string GetSensorDataForCompany2()
    {
        var jsonData =
            "{\"CompanyId\":2,\"Company\":\"Foo2\",\"Devices\":[{\"DeviceID\":1,\"Name\":\"XYZ-100\",\"StartDateTime\":\"08-18-2020 10:30:00\",\"SensorData\":[{\"SensorType\":\"TEMP\",\"DateTime\":\"08-18-2020 10:35:00\",\"Value\":32.15},{\"SensorType\":\"TEMP\",\"DateTime\":\"08-18-2020 10:40:00\",\"Value\":33.15},{\"SensorType\":\"TEMP\",\"DateTime\":\"08-18-2020 10:45:00\",\"Value\":34.15},{\"SensorType\":\"HUM\",\"DateTime\":\"08-18-2020 10:35:00\",\"Value\":90.5},{\"SensorType\":\"HUM\",\"DateTime\":\"08-18-2020 10:40:00\",\"Value\":91.5},{\"SensorType\":\"HUM\",\"DateTime\":\"08-18-2020 10:45:00\",\"Value\":92.5}]},{\"DeviceID\":2,\"Name\":\"XYZ-200\",\"StartDateTime\":\"08-19-2020 10:30:00\",\"SensorData\":[{\"SensorType\":\"TEMP\",\"DateTime\":\"08-19-2020 10:35:00\",\"Value\":42.15},{\"SensorType\":\"TEMP\",\"DateTime\":\"08-19-2020 10:40:00\",\"Value\":43.15},{\"SensorType\":\"TEMP\",\"DateTime\":\"08-19-2020 10:45:00\",\"Value\":44.15},{\"SensorType\":\"HUM\",\"DateTime\":\"08-19-2020 10:35:00\",\"Value\":91.5},{\"SensorType\":\"HUM\",\"DateTime\":\"08-19-2020 10:40:00\",\"Value\":92.5},{\"SensorType\":\"HUM\",\"DateTime\":\"08-19-2020 10:45:00\",\"Value\":93.5}]}]}";
        return jsonData;
    }

    public static Mock<ICompany1SensorDataParser> GetParser()
    {
        var mockParser = new Mock<ICompany1SensorDataParser>();
        mockParser.Setup(p => p.Parse(GetSensorDataForCompany2())).Returns(SensorList);

        return mockParser;
    }
}