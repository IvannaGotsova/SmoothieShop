using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class FeedbackController : Controller
    {
        /// <summary>
        /// Controls Feedback functionalities.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
