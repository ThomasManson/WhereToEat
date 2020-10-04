namespace WhereToEat.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    using AutoFixture;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NSubstitute;

    using WhereToEat.Configuration;
    using WhereToEat.Models;
    using WhereToEat.Services;

    [TestClass]

    public class FoodTruckServiceTests
    {
        [TestMethod]
        public async Task GetFoodTrucksWithinAreaAsync_Returns_List()
        {
            // arrange
            var fixture = new Fixture();

            var trucks = fixture.CreateMany<FoodTruck>();
            var config = fixture.Create<AppConfigOptions>();
            config.FoodTruckUrl = "https://somewhere.com/";

            var optionsMock = Substitute.For<IOptionsSnapshot<AppConfigOptions>>();
            optionsMock.Value.Returns(config);

            var loggerMock = Substitute.For<ILogger<FoodTruckService>>();

            var messageHandler = new TestMessageHandler(System.Net.HttpStatusCode.OK, JsonSerializer.Serialize(trucks));
            var httpClient = new HttpClient(messageHandler);
            
            // act
            var service = new FoodTruckService(httpClient, optionsMock, loggerMock);
            var result = await service.GetFoodTrucksWithinAreaAsync(new Position(1, 2), new Position(3, 4));

            // assert
            Assert.IsNotNull(service);
            Assert.AreEqual(trucks.Count(), result.Count());
            Assert.AreEqual(trucks.First().applicant, result.First().applicant);
        }
    }
}
