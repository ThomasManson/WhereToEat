using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using WhereToEat.Configuration;
using WhereToEat.Models;

namespace WhereToEat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptionsSnapshot<AppConfigOptions> appConfigSnapshot;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IOptionsSnapshot<AppConfigOptions> appConfigSnapshot, ILogger<HomeController> logger)
        {
            this.appConfigSnapshot = appConfigSnapshot;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            var key = this.appConfigSnapshot.Value.MapApiKey;
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
