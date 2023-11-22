using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class ApplicationUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
