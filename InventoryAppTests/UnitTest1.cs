using InventoryApp.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace InventoryAppTests
{
    [TestFixture]
    public class Tests
    {
        private WeatherForecastController weatherForecastController;
        private readonly Mock<ILogger<WeatherForecastController>> loggerMock = new();

        [SetUp]
        public void Setup()
        {         
            weatherForecastController = new WeatherForecastController(loggerMock.Object);
        }

        [Test]
        public void Tests1()
        {
            var result =weatherForecastController.Get();
            Assert.IsNotNull(result);
        }
    }
}