using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
