using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.SmoothieModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    [Authorize(Roles = "ProductUser, Admin")]
    /// <summary>
    /// Controls Smoothie functionalities.
    /// </summary>
    public class SmoothieController : Controller
    {
        private readonly ISmoothieService smoothieService;
        private readonly IMenuService menuService;
        private readonly IOrderService orderService;
        private readonly IIngredientService ingredientService;
        public SmoothieController(ISmoothieService smoothieService, IMenuService menuUserService, IOrderService orderService, IIngredientService ingredientService)
        {
            this.smoothieService = smoothieService;
            this.menuService = menuUserService;
            this.orderService = orderService;
            this.ingredientService = ingredientService;
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
        /// This method returns all available smoothies.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllSmoothies()
        {
            try
            {
                var smoothies = await
                    smoothieService
                   .GetAllSmoothies();

                return View(smoothies);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddSmoothie()
        {
            var modelSmoothie = new AddSmoothieModel()
            {
                Menus = await
                menuService.GetMenusForSelect(),
                Orders = await
                orderService.GetOrdersForSelect(),
                Ingredients = await
                ingredientService.GetIngredientsForSelect(),
            };

            return View(modelSmoothie);
        }
        /// <summary>
        /// This method is used to add a smoothie.
        /// </summary>
        /// <param name="addSmoothieModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSmoothie(AddSmoothieModel addSmoothieModel)
        {
            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                addSmoothieModel.Menus = await
                menuService.GetMenusForSelect();
                addSmoothieModel.Orders = await
                orderService.GetOrdersForSelect();
                addSmoothieModel.Ingredients = await
                ingredientService.GetIngredientsForSelect();

                return View(addSmoothieModel);
            }

            try
            {
                await smoothieService
                    .Add(addSmoothieModel);

                TempData["message"] = $"You have successfully added a smoothie!";

                return RedirectToAction("AllSmoothies", "Smoothie");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                addSmoothieModel.Menus = await
                menuService.GetMenusForSelect();
                addSmoothieModel.Orders = await
                orderService.GetOrdersForSelect();
                addSmoothieModel.Ingredients = await
                ingredientService.GetIngredientsForSelect();

                return View(addSmoothieModel);
            }

        }
        /// <summary>
        /// This method returns a details about particular smoothie with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsSmoothie(int id)
        {
            //check if the smoothie is null
            if (
                await smoothieService
                .GetSmoothieDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var smoothieModel = await
                smoothieService
                .GetSmoothieDetailsById(id);

                return View(smoothieModel);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This metod creates a form for editing a particular smoothie with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditSmoothie(int id)
        {
            //check if the smoothie is null
            if (await smoothieService
                .GetSmoothieDetailsById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                var editFormModel = await
                       smoothieService
                       .EditCreateForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }



        }
        /// <summary>
        /// This method is used to edit a particular smoothie with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editSmoothieModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditSmoothie(int id, EditSmoothieModel editSmoothieModel)
        {
            //check if the smoothie is null
            if (await smoothieService
                .GetSmoothieDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await smoothieService
                    .Edit(id, editSmoothieModel);

                TempData["message"] = $"You have successfully edited a smoothie!";

                return RedirectToAction("AllSmoothies", "Smoothie");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(editSmoothieModel);
            }
        }
        /// <summary>
        /// This metod creates a form for deleting a particular smoothie with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteSmoothie(int id)
        {
            //check if the smoothie is null
            if (await smoothieService
                .GetSmoothieDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var editFormModel = await
               smoothieService
               .DeleteSmoothieForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to delete a particular smoothie.
        /// </summary>
        /// <param name="deleteSmoothieModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteSmoothie(DeleteSmoothieModel deleteSmoothieModel)
        {
            //check if the smoothie is null
            if (await smoothieService
                .GetSmoothieById(deleteSmoothieModel.SmoothieId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await smoothieService
                    .Delete(deleteSmoothieModel.SmoothieId);

                TempData["message"] = $"You have successfully deleted a smoothie!";

                return RedirectToAction("AllSmoothies", "Smoothie");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(deleteSmoothieModel);
            }
        }

    }
}