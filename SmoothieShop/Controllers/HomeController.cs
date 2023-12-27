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
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}