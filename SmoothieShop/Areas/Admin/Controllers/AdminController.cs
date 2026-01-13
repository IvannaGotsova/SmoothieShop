using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;

namespace SmoothieShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    /// <summary>
    ///  Controls all functions of Admin;
    /// </summary>
    public class AdminController : Controller
    {
        private readonly IApplicationUserService applicationUser;
        private readonly ICustomerService customerService;
        private readonly ICustomerUserService customerUserService;
        private readonly IFeedbackService feedbackService;
        private readonly IIngredientService ingredientService;
        private readonly IMenuService menuService;
        private readonly IOrderService orderService;
        private readonly IProductUserService productUserService;
        private readonly ISmoothieService smoothieService;

        public AdminController(IApplicationUserService applicationUser, 
                               ICustomerService customerService, 
                               ICustomerUserService customerUserService, 
                               IFeedbackService feedbackService, 
                               IIngredientService ingredientService, 
                               IMenuService menuService, 
                               IOrderService orderService, 
                               IProductUserService productUserService, 
                               ISmoothieService smoothieService)
        {
            this.applicationUser = applicationUser;
            this.customerService = customerService;
            this.customerUserService = customerUserService;
            this.feedbackService = feedbackService;
            this.ingredientService = ingredientService;
            this.menuService = menuService;
            this.orderService = orderService;
            this.productUserService = productUserService;
            this.smoothieService = smoothieService;
        }
        /// <summary>
        /// Returns Index page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllCounts()
        {
            TempData["message"] = $"All Counts Index";

            return View();
        }
        /// <summary>
        /// Returns AllApplicationUsersCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllApplicationUsersCount()
        {
            try
            {
                var count =
                applicationUser
                .Count();

                TempData["message"] = $"All Application Users Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// Returns AllCustomerUsersCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllCustomersCount()
        {
            try
            {
                var count =
                customerService
                .Count();

                TempData["message"] = $"All Customers Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// Returns AllCustomerUsersCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllCustomerUsersCount()
        {
            try
            {
                var count =
                customerUserService
                .Count();

                TempData["message"] = $"All Customer Users Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// Returns AllFeedbacksCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllFeedbacksCount()
        {
            try
            {
                var count =
                feedbackService
                .Count();

                TempData["message"] = $"All Feedbacks Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// Returns AllIngredientsCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllIngredientsCount()
        {
            try
            {
                var count =
                ingredientService
                .Count();

                TempData["message"] = $"All Ingredients Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// Returns AllMenusCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllMenusCount()
        {
            try
            {
                var count =
                menuService
                .Count();

                TempData["message"] = $"All Menus Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// Returns AllOrdersCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllOrdersCount()
        {
            try
            {
                var count =
                orderService
                .Count();

                TempData["message"] = $"All Orders Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// Returns AllProductUsersCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllProductUsersCount()
        {
            try
            {
                var count =
                productUserService
                .Count();

                TempData["message"] = $"All Product Users Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// Returns AllSmoothiesCount page
        /// </summary>
        /// <returns></returns>
        public IActionResult AllSmoothiesCount()
        {
            try
            {
                var count =
                smoothieService
                .Count();

                TempData["message"] = $"All Smoothies Count";

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
    }
}
