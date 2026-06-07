using Microsoft.AspNetCore.Mvc;

namespace RedCloud.Controllers
{
    public class ReportDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
