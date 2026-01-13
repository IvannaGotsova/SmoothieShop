using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Models.MenuModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    /// <summary>
    /// Controls Menu functionalities.
    /// </summary>
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;
        private readonly ISmoothieService smoothieService;

        public MenuController(IMenuService menuService,
                              ISmoothieService smoothieService)
        {
            this.menuService = menuService;
            this.smoothieService = smoothieService;
        }
        /// <summary>
        /// This method returns index view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            TempData["message"] = $"Menu Index!";

            return View();
        }
        /// <summary>
        /// This method returns all available menus.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllMenus()
        {
            try
            {
                var menus = await
                    menuService
                   .GetAllMenus();

                TempData["message"] = $"All Menus!";

                return View(menus);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [Authorize(Roles = "ProductUser, Admin")]
        /// <summary>
        /// This method is used to add a menu.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddMenu()
        {
            var modelMenu = new AddMenuModel()
            {
                Smoothies = await
                smoothieService.GetSmoothiesForSelect()
            };

            TempData["message"] = $"Here you can add a menu!";

            return View(modelMenu);
        }
        [Authorize(Roles = "ProductUser, Admin")]
        /// <summary>
        /// This method is used to add a menu.
        /// </summary>
        /// <param name="addMenuModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddMenu(AddMenuModel addMenuModel)
        {
            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                addMenuModel.Smoothies = await
                smoothieService.GetSmoothiesForSelect();

                return View(addMenuModel);
            }

            try
            {
                await menuService
                    .Add(addMenuModel);

                TempData["message"] = $"You have successfully added a menu!";

                return RedirectToAction("AllMenus", "Menu");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                addMenuModel.Smoothies = await
                smoothieService.GetSmoothiesForSelect();

                return View(addMenuModel);
            }
        }
        /// <summary>
        /// This method returns a details about particular menu with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsMenu(int id)
        {
            //check if the menu is null
            if (
                await menuService
                .GetMenuDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var menuModel = await
                menuService
                .GetMenuDetailsById(id);

                TempData["message"] = $"Here you can see menu details";

                return View(menuModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [Authorize(Roles = "ProductUser, Admin")]
        /// <summary>
        /// This metod creates a form for editing a particular menu with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditMenu(int id)
        {
            //check if the menu is null
            if (await menuService
                .GetMenuDetailsById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                var editFormModel = await
                       menuService
                       .EditCreateForm(id);

                editFormModel.Smoothies = await
                smoothieService.GetSmoothiesForSelect();

                editFormModel.SelectedSmoothiesIds = await
                menuService.GetSmoothiesIdsByMenu(id);

                TempData["message"] = $"Here you can edit a menu!";

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [Authorize(Roles = "ProductUser, Admin")]
        /// <summary>
        /// This method is used to edit a particular menu with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editMenuModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditMenu(int id, EditMenuModel editMenuModel)
        {
            //check if the menu is null
            if (await menuService
                .GetMenuDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await menuService
                    .Edit(id, editMenuModel);

                TempData["message"] = $"You have successfully edited a menu!";

                return RedirectToAction("AllMenus", "Menu");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                editMenuModel.Smoothies = await
                smoothieService.GetSmoothiesForSelect();

                return View(editMenuModel);
            }
        }
        [Authorize(Roles = "ProductUser, Admin")]
        /// <summary>
        /// This metod creates a form for deleting a particular menu with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            //check if the menu is null
            if (await menuService
                .GetMenuDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var deleteFormModel = await
               menuService
               .DeleteMenuForm(id);

                TempData["message"] = $"Here you can delete a menu!";

                return View(deleteFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [Authorize(Roles = "ProductUser, Admin")]
        /// <summary>
        /// This method is used to delete a particular menu.
        /// </summary>
        /// <param name="deleteMenuModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteMenu(DeleteMenuModel deleteMenuModel)
        {
            //check if the menu is null
            if (await menuService
                .GetMenuById(deleteMenuModel.MenuId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await menuService
                    .Delete(deleteMenuModel.MenuId);

                TempData["message"] = $"You have successfully deleted a menu!";

                return RedirectToAction("AllMenus", "Menu");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(deleteMenuModel);
            }
        }
        [Authorize]
        /// <summary>
        /// This method returns all orders of a menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> MenuOrders(int id)
        {
            //check if the menu is null
            if (await menuService
                .GetMenuById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var orders = await menuService.GetOrdersByMenu(id);

                TempData["message"] = $"Here you can see all orders by menu";

                return View(orders);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return RedirectToAction("AllMenus", "Menu", new { area = "" });
            }
        }
        [Authorize]
        /// <summary>
        /// This method returns all smoothies in a menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> MenuSmoothies(int id)
        {
            //check if the menu is null
            if (await menuService
                .GetMenuById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var smoothies = await menuService.GetSmoothiesByMenu(id);

                TempData["message"] = $"Here you can see all smoothies by menu";

                return View(smoothies);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return RedirectToAction("AllMenus", "Menu", new { area = "" });
            }
        }
        [Authorize(Roles = "CustomerUser, Admin")]
        /// <summary>
        /// This method returns all menus ordered by a customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> MenusCustomer(int id)
        {
            //check if the customer is null
            if (await menuService
                .GetAllMenusByCustomer(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var menus = await menuService.GetAllMenusByCustomer(id);

                TempData["message"] = $"Here you can see all menus by customer";

                return View(menus);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return RedirectToAction("AllMenus", "Menu", new { area = "" });
            }
        }
    }
}

