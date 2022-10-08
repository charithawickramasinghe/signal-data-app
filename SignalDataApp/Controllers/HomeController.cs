using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SignalDataApp.Business;
using SignalDataApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SignalDataApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITokenService tokenService;
        private readonly IMainService mainService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITokenService tokenService, IMainService mainService, ILogger<HomeController> logger)
        {
            this.tokenService = tokenService;
            this.mainService = mainService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //get an access token and save in a session.
            var token = await tokenService.GetToken();
            HttpContext.Session.SetString("AuthToken", token);

            //Call main service and get data.
            var data = await mainService.GetBuildingSignalData(HttpContext.Session.GetString("AuthToken"));

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
