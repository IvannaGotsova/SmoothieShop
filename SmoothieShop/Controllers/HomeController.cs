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
        /// <summary>
        /// This method creates news page.
        /// </summary>
        /// <returns></returns>
        public IActionResult News()
        {
            return View();
        }
        /// <summary>
        /// This method creates privacy page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// This method creates contacts page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Contacts()
        {
            return View();
        }
        /// <summary>
        /// This method creates FAQs page.
        /// </summary>
        /// <returns></returns>
        public IActionResult FAQs()
        {
            return View();
        }
        /// <summary>
        /// This method creates AboutUs page.
        /// </summary>
        /// <returns></returns>
        public IActionResult AboutUs()
        {
            return View();
        }
        /// <summary>
        /// This method creates error page.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}