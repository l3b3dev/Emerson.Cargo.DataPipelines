using Emerson.Cargo.DataPipelines.Infrastructure.SensorParser;
using Emerson.Cargo.DataPipelines.Infrastructure.UnitTests.Mocks;

namespace Emerson.Cargo.DataPipelines.Infrastructure.UnitTests
{
    [TestClass]
    public class Company1SensorDataParserTests
    {
        [TestMethod]
        public void Company1SensorDataParser_ForProvidedCompany1SensorData_AllStatisticsIsCorrect()
        {
            //arrange
            var sensorPayload = SensorDataMocks.GetSensorDataForCompany1();
            var parser = new Company1SensorDataParser();

            //act
            var result = parser.Parse(sensorPayload).ToList();

            //assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].CompanyId);
            Assert.AreEqual("Foo1", result[0].CompanyName);
            Assert.AreEqual(3, result[0].TemperatureCount);
            Assert.AreEqual(3, result[0].HumidityCount);
            Assert.AreEqual(23.15, Math.Round(result[0].AverageTemperature.Value,2));
            Assert.AreEqual(81.5, Math.Round(result[0].AverageHumdity.Value, 2));
            Assert.AreEqual(new DateTime(2020,8,17,10,35,0), result[0].FirstReadingDtm);
            Assert.AreEqual(new DateTime(2020, 8, 17, 10, 45, 0), result[0].LastReadingDtm);
        }

        [TestMethod]
        public void Company1SensorDataParser_ForProvidedCompany1SensorData_CheckSensorTimeStampOrdering()
        {
            //arrange
            var sensorPayload = SensorDataMocks.GetSensorDataForCompany1WithShuffledDates();
            var parser = new Company1SensorDataParser();

            //act
            var result = parser.Parse(sensorPayload).ToList();

            //assert
            Assert.AreEqual(new DateTime(2020, 8, 17, 10, 11, 0), result[0].FirstReadingDtm);
            Assert.AreEqual(new DateTime(2020, 8, 17, 10, 48, 0), result[0].LastReadingDtm);
        }

        [TestMethod]
        public void Company2SensorDataParser_ForProvidedCompany2SensorData_AllStatisticsIsCorrect()
        {
            //arrange
            var sensorPayload = SensorDataMocks.GetSensorDataForCompany2();
            var parser = new Company2SensorDataParser();

            //act
            var result = parser.Parse(sensorPayload).ToList();

            //assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result[0].CompanyId);
            Assert.AreEqual("Foo2", result[0].CompanyName);
            Assert.AreEqual(3, result[0].TemperatureCount);
            Assert.AreEqual(3, result[0].HumidityCount);
            Assert.AreEqual(33.15, Math.Round(result[0].AverageTemperature.Value, 2));
            Assert.AreEqual(91.5, Math.Round(result[0].AverageHumdity.Value, 2));
            Assert.AreEqual(new DateTime(2020, 8, 18, 10, 35, 0), result[0].FirstReadingDtm);
            Assert.AreEqual(new DateTime(2020, 8, 18, 10, 45, 0), result[0].LastReadingDtm);
        }

    }
}