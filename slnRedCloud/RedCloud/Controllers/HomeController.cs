using Microsoft.AspNetCore.Mvc;
using RedCloud.Custom_Action_Filter;
using RedCloud.Models;
using System.Diagnostics;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;

namespace RedCloud.Controllers
{
    [NoCache]
    [AdminAuthorizationFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [NoCache]
        [AdminAuthorizationFilter]
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
