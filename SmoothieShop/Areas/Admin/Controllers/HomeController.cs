using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    /// <summary>
    ///  Controls all functions of Home Controller of Admin;
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
