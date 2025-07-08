using System.Diagnostics;
using day11.Models;
using Microsoft.AspNetCore.Mvc;

namespace day11.Controllers
{
    public class PhnHomeController : Controller
    {
        private readonly ILogger<PhnHomeController> _logger;

        public PhnHomeController(ILogger<PhnHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PhnIndex()
        {
            return View();
        }

        public IActionResult PhnAbout()
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
