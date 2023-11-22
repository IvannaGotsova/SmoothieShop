using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class SmoothieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
