using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    /// <summary>
    /// Controls Customer functionalities.
    /// </summary>
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
