using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogger<LogsController> _logger;
        private readonly Context _context;

        public LogsController(ILogger<LogsController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            _context.Logs.AddRange(new Log() { UserIPAddress = remoteIpAddress, UserRequestTime = DateTime.Now });
            _context.SaveChanges();

            var logInfos = _context.Logs.OrderByDescending(x => x.LogId).Take(10).ToList();

            return View(logInfos);
        }
    }
}
