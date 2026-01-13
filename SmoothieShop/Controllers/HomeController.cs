using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Models;
using System.Diagnostics;

namespace SmoothieShop.Controllers
{
    /// <summary>
    /// Controls Home functionalities.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// This method creates index page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            TempData["message"] = $"Home!";

            return View();
        }
        /// <summary>
        /// This method creates news page.
        /// </summary>
        /// <returns></returns>
        public IActionResult News()
        {
            TempData["message"] = $"News!";

            return View();
        }
        /// <summary>
        /// This method creates privacy page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            TempData["message"] = $"Privacy!";
            return View();
        }
        /// <summary>
        /// This method creates contacts page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Contacts()
        {
            TempData["message"] = $"Contacts!";

            return View();
        }
        /// <summary>
        /// This method creates FAQs page.
        /// </summary>
        /// <returns></returns>
        public IActionResult FAQs()
        {
            TempData["message"] = $"FAQs!";

            return View();
        }
        /// <summary>
        /// This method creates AboutUs page.
        /// </summary>
        /// <returns></returns>
        public IActionResult AboutUs()
        {
            TempData["message"] = $"About Us!";

            return View();
        }
        /// <summary>
        /// This method creates error page.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            TempData["message"] = $"Error!";

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}