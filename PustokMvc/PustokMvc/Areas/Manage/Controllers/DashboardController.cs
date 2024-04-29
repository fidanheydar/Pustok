using Microsoft.AspNetCore.Mvc;

namespace PustokMvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
