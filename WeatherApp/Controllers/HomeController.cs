using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            string apiKey = "3cf634e2bd303296198d7530f9fb18b0";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + apiKey;

            XDocument document = XDocument.Load(connection);

            var temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value; ;
            ViewBag.temperature = (temp.Substring(0, 2));

            ViewBag.icon = document.Descendants("weather").ElementAt(0).Attribute("icon").Value;

            ViewBag.weather = document.Descendants("weather").ElementAt(0).Attribute("value").Value;

            var feels = document.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
            ViewBag.feelslike = (feels.Substring(0, 2));

            var humidity = document.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            ViewBag.humidity = (humidity.Substring(0, 2));

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
