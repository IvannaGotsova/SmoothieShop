using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class IngredientController : Controller
    {
        /// <summary>
        /// Controls Ingredient functionalities.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
