using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    /// <summary>
    /// Controls CustomerUser functionalities.
    /// </summary>
    public class CustomerUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
