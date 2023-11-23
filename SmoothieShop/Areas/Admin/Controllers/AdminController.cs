using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
