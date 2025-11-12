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

        public AdminController(IApplicationUserService applicationUser, ICustomerService customerService, ICustomerUserService customerUserService, IFeedbackService feedbackService, IIngredientService ingredientService, IMenuService menuService, IOrderService orderService, IProductUserService productUserService, ISmoothieService smoothieService)
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllCounts()
        {
            return View();
        }

        public IActionResult AllApplicationUsersCount()
        {
            try
            {
                var count =
                applicationUser
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        public IActionResult AllCustomersCount()
        {
            try
            {
                var count =
                customerService
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        public IActionResult AllCustomerUsersCount()
        {
            try
            {
                var count =
                customerUserService
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        public IActionResult AllFeedbacksCount()
        {
            try
            {
                var count =
                feedbackService
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        public IActionResult AllIngredientsCount()
        {
            try
            {
                var count =
                ingredientService
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        public IActionResult AllMenusCount()
        {
            try
            {
                var count =
                menuService
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        public IActionResult AllOrdersCount()
        {
            try
            {
                var count =
                orderService
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        public IActionResult AllProductUsersCount()
        {
            try
            {
                var count =
                productUserService
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        public IActionResult AllSmoothiesCount()
        {
            try
            {
                var count =
                smoothieService
                .Count();

                return View(count);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
    }
}
