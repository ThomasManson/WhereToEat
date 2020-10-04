using System.Reflection.Emit;

using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WhereToEat.Configuration;
using WhereToEat.Controllers;

namespace WhereToEat.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void ResultHasKey()
        {
            // arrange
            var appConfig = new AppConfigOptions
            {
                MapApiKey = "someKey"
            };

            var optionsMock = Substitute.For<IOptionsSnapshot<AppConfigOptions>>();
            optionsMock.Value.Returns(appConfig);

            var loggerMock = Substitute.For<ILogger<HomeController>>();

            // act 
            var controller = new HomeController(optionsMock, loggerMock);
            var result = controller.Index();
            var viewResult = result as ViewResult;

            // assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual("someKey", viewResult.ViewData["key"]);
        }

        [TestMethod]
        public void PrivacyReturnsView()
        {
            // arrange
            var appConfig = new AppConfigOptions
            {
                MapApiKey = "someKey"
            };

            var optionsMock = Substitute.For<IOptionsSnapshot<AppConfigOptions>>();
            optionsMock.Value.Returns(appConfig);

            var loggerMock = Substitute.For<ILogger<HomeController>>();

            // act 
            var controller = new HomeController(optionsMock, loggerMock);
            var result = controller.Privacy();
            var viewResult = result as ViewResult;

            // assert
            Assert.IsNotNull(viewResult);
        }
    }
}
