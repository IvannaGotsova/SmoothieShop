using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Models.MenuModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    [Authorize(Roles = "ProductUser, Admin")]
    /// <summary>
    /// Controls Menu functionalities.
    /// </summary>
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;
        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        /// <summary>
        /// This method returns index view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
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

                return View(menus);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddMenu()
        {
            var modelMenu = await Task.Run(() => new AddMenuModel());

            return View(modelMenu);
        }
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

                return View(menuModel);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
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

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }



        }
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

                return View(editMenuModel);
            }
        }
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
                var editFormModel = await
               menuService
               .DeleteMenuForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
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

    }
}

