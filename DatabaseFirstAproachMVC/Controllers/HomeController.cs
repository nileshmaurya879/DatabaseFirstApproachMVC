using DatabaseFirstAproachMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DatabaseFirstAproachMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseFirstApproachContext _databaseFirstApproachContext;

        public HomeController(ILogger<HomeController> logger, DatabaseFirstApproachContext databaseFirstApproachContext)
        {
            _logger = logger;
            _databaseFirstApproachContext = databaseFirstApproachContext;
        }

        public IActionResult Index()
        {
            var data = _databaseFirstApproachContext.Categories.ToList();
            return View(data);
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