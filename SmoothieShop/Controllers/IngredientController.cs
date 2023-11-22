using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
