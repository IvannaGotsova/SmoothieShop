using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
