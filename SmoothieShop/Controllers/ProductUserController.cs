using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class ProductUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
