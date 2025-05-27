using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhnDay06.Models;

namespace PhnDay06.Controllers
{
    public class PhnHomeController : Controller
    {
        private readonly ILogger<PhnHomeController> _logger;

        public PhnHomeController(ILogger<PhnHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
