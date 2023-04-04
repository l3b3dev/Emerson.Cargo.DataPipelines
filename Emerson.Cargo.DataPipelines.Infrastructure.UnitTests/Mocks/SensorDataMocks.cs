namespace Emerson.Cargo.DataPipelines.Infrastructure.UnitTests.Mocks;

public class SensorDataMocks
{
    public static string GetSensorDataForCompany1()
    {
        var jsonData =
            "{\"PartnerId\":1,\"PartnerName\":\"Foo1\",\"Trackers\":[{\"Id\":1,\"Model\":\"ABC-100\",\"ShipmentStartDtm\":\"08-17-2020 10:30:00\",\"Sensors\":[{\"Id\":100,\"Name\":\"Temperature\",\"Crumbs\":[{\"CreatedDtm\":\"08-17-2020 10:35:00\",\"Value\":22.15},{\"CreatedDtm\":\"08-17-2020 10:40:00\",\"Value\":23.15},{\"CreatedDtm\":\"08-17-2020 10:45:00\",\"Value\":24.15}]},{\"Id\":101,\"Name\":\"Humidty\",\"Crumbs\":[{\"CreatedDtm\":\"08-17-2020 10:35:00\",\"Value\":80.5},{\"CreatedDtm\":\"08-17-2020 10:40:00\",\"Value\":81.5},{\"CreatedDtm\":\"08-17-2020 10:45:00\",\"Value\":82.5}]}]},{\"Id\":2,\"Model\":\"ABC-200\",\"ShipmentStartDtm\":\"08-18-2020 10:30:00\",\"Sensors\":[{\"Id\":200,\"Name\":\"Temperature\",\"Crumbs\":[{\"CreatedDtm\":\"08-18-2020 10:35:00\",\"Value\":23.15},{\"CreatedDtm\":\"08-18-2020 10:40:00\",\"Value\":24.15},{\"CreatedDtm\":\"08-18-2020 10:45:00\",\"Value\":25.15}]},{\"Id\":201,\"Name\":\"Humidty\",\"Crumbs\":[{\"CreatedDtm\":\"08-18-2020 10:35:00\",\"Value\":81.5},{\"CreatedDtm\":\"08-18-2020 10:40:00\",\"Value\":82.5},{\"CreatedDtm\":\"08-18-2020 10:45:00\",\"Value\":83.5}]}]}]}";
        return jsonData;
    }

    public static string GetSensorDataForCompany1WithShuffledDates()
    {
        var jsonData =
            "{\"PartnerId\":1,\"PartnerName\":\"Foo1\",\"Trackers\":[{\"Id\":1,\"Model\":\"ABC-100\",\"ShipmentStartDtm\":\"08-17-2020 10:30:00\",\"Sensors\":[{\"Id\":100,\"Name\":\"Temperature\",\"Crumbs\":[{\"CreatedDtm\":\"08-17-2020 10:29:00\",\"Value\":22.15},{\"CreatedDtm\":\"08-17-2020 10:48:00\",\"Value\":23.15},{\"CreatedDtm\":\"08-17-2020 10:41:00\",\"Value\":24.15}]},{\"Id\":101,\"Name\":\"Humidty\",\"Crumbs\":[{\"CreatedDtm\":\"08-17-2020 10:35:00\",\"Value\":80.5},{\"CreatedDtm\":\"08-17-2020 10:11:00\",\"Value\":81.5},{\"CreatedDtm\":\"08-17-2020 10:45:00\",\"Value\":82.5}]}]},{\"Id\":2,\"Model\":\"ABC-200\",\"ShipmentStartDtm\":\"08-18-2020 10:30:00\",\"Sensors\":[{\"Id\":200,\"Name\":\"Temperature\",\"Crumbs\":[{\"CreatedDtm\":\"08-18-2020 10:35:00\",\"Value\":23.15},{\"CreatedDtm\":\"08-18-2020 10:40:00\",\"Value\":24.15},{\"CreatedDtm\":\"08-18-2020 10:45:00\",\"Value\":25.15}]},{\"Id\":201,\"Name\":\"Humidty\",\"Crumbs\":[{\"CreatedDtm\":\"08-18-2020 10:35:00\",\"Value\":81.5},{\"CreatedDtm\":\"08-18-2020 10:40:00\",\"Value\":82.5},{\"CreatedDtm\":\"08-18-2020 10:45:00\",\"Value\":83.5}]}]}]}";
        return jsonData;
    }

    public static string GetSensorDataForCompany2()
    {
        var jsonData =
            "{\"CompanyId\":2,\"Company\":\"Foo2\",\"Devices\":[{\"DeviceID\":1,\"Name\":\"XYZ-100\",\"StartDateTime\":\"08-18-2020 10:30:00\",\"SensorData\":[{\"SensorType\":\"TEMP\",\"DateTime\":\"08-18-2020 10:35:00\",\"Value\":32.15},{\"SensorType\":\"TEMP\",\"DateTime\":\"08-18-2020 10:40:00\",\"Value\":33.15},{\"SensorType\":\"TEMP\",\"DateTime\":\"08-18-2020 10:45:00\",\"Value\":34.15},{\"SensorType\":\"HUM\",\"DateTime\":\"08-18-2020 10:35:00\",\"Value\":90.5},{\"SensorType\":\"HUM\",\"DateTime\":\"08-18-2020 10:40:00\",\"Value\":91.5},{\"SensorType\":\"HUM\",\"DateTime\":\"08-18-2020 10:45:00\",\"Value\":92.5}]},{\"DeviceID\":2,\"Name\":\"XYZ-200\",\"StartDateTime\":\"08-19-2020 10:30:00\",\"SensorData\":[{\"SensorType\":\"TEMP\",\"DateTime\":\"08-19-2020 10:35:00\",\"Value\":42.15},{\"SensorType\":\"TEMP\",\"DateTime\":\"08-19-2020 10:40:00\",\"Value\":43.15},{\"SensorType\":\"TEMP\",\"DateTime\":\"08-19-2020 10:45:00\",\"Value\":44.15},{\"SensorType\":\"HUM\",\"DateTime\":\"08-19-2020 10:35:00\",\"Value\":91.5},{\"SensorType\":\"HUM\",\"DateTime\":\"08-19-2020 10:40:00\",\"Value\":92.5},{\"SensorType\":\"HUM\",\"DateTime\":\"08-19-2020 10:45:00\",\"Value\":93.5}]}]}";
        return jsonData;
    }
}