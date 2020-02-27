using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.Extensions.Logging;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Controllers
{
   // [Area("Admin") ]
   //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello {Name}", "Shahed");
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

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Test(TestModel model)
        {
            try
            {
                var status = false;
                if (ModelState.IsValid)
                {
                    status = true;
                }
                throw new Exception("Fake Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Test Failed");
            }
            return View();
        }
    }
}
