using Microsoft.AspNetCore.Mvc;

namespace RedCloud.Controllers
{
    public class AdminReportDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
