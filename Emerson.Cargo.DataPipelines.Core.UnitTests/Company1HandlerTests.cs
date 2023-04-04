using Emerson.Cargo.DataPipelines.Core.Contracts;
using Emerson.Cargo.DataPipelines.Core.Features.DeviceData.Sensors;
using Emerson.Cargo.DataPipelines.Core.UnitTests.Mocks;
using Moq;

namespace Emerson.Cargo.DataPipelines.Core.UnitTests
{
    [TestClass]
    public class Company1HandlerTests
    {
        private readonly Mock<ICompany1SensorDataParser> _mockCompany1SensorParser = SensorDataMocks.GetParser();

        [TestMethod]
        public async Task Company1Handler_TestMediatorRouting()
        {
            //arrange
            var handler = new Company1Handler(_mockCompany1SensorParser.Object);

            //act
            var result = (await handler.Handle(new Company1Query(SensorDataMocks.GetSensorDataForCompany2()), CancellationToken.None)).ToList();

            //asert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(SensorDataMocks.SensorList[0].CompanyId, result[0].CompanyId);
            Assert.AreEqual(SensorDataMocks.SensorList[0].CompanyName, result[0].CompanyName);
            Assert.AreEqual(1, result[0].TemperatureCount);
            Assert.AreEqual(1, result[0].HumidityCount);
        }
    }
}