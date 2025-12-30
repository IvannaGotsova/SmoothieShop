using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Core.Services;
using SmoothieShop.Data.Models.IngredientModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    [Authorize]
    /// <summary>
    /// Controls Ingredient functionalities.
    /// </summary>
    public class IngredientController : Controller
    {
        private readonly IIngredientService ingredientService;
        public IngredientController(IIngredientService ingredientService)
        {
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
        /// This method returns all available ingredients.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllIngredients()
        {
            try
            {
                var ingredients = await
                    ingredientService
                   .GetAllIngredients();

                return View(ingredients);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [Authorize(Roles = "ProductUser, Admin")]
        [HttpGet]
        public async Task<IActionResult> AddIngredient()
        {
            var modelIngredient = await Task.Run(() => new AddIngredientModel());

            return View(modelIngredient);
        }
        /// <summary>
        /// This method is used to add a ingredient.
        /// </summary>
        /// <param name="addIngredientModel"></param>
        /// <returns></returns>
        [Authorize(Roles = "ProductUser, Admin")]
        [HttpPost]
        public async Task<IActionResult> AddIngredient(AddIngredientModel addIngredientModel)
        {
            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                return View(addIngredientModel);
            }

            try
            {
                await ingredientService
                    .Add(addIngredientModel);

                TempData["message"] = $"You have successfully added a ingredient!";

                return RedirectToAction("AllIngredients", "Ingredient");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(addIngredientModel);
            }

        }
        /// <summary>
        /// This method returns a details about particular ingredient with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsIngredient(int id)
        {
            //check if the ingredient is null
            if (
                await ingredientService
                .GetIngredientDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var ingredientModel = await
                ingredientService
                .GetIngredientDetailsById(id);

                return View(ingredientModel);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This metod creates a form for editing a particular ingredient with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "ProductUser, Admin")]
        [HttpGet]
        public async Task<IActionResult> EditIngredient(int id)
        {
            //check if the ingredient is null
            if (await ingredientService
                .GetIngredientDetailsById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                var editFormModel = await
                       ingredientService
                       .EditCreateForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to edit a particular ingredient with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editIngredientModel"></param>
        /// <returns></returns>
        [Authorize(Roles = "ProductUser, Admin")]
        [HttpPost]
        public async Task<IActionResult> EditIngredient(int id, EditIngredientModel editIngredientModel)
        {
            //check if the ingredient is null
            if (await ingredientService
                .GetIngredientDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await ingredientService
                    .Edit(id, editIngredientModel);

                TempData["message"] = $"You have successfully edited a ingredient!";

                return RedirectToAction("AllIngredients", "Ingredient");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(editIngredientModel);
            }
        }
        /// <summary>
        /// This metod creates a form for deleting a particular ingredient with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "ProductUser, Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            //check if the ingredient is null
            if (await ingredientService
                .GetIngredientDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var deleteFormModel = await
               ingredientService
               .DeleteIngredientForm(id);

                return View(deleteFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to delete a particular ingredient.
        /// </summary>
        /// <param name="deleteIngredientModel"></param>
        /// <returns></returns>
        [Authorize(Roles = "ProductUser, Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteIngredient(DeleteIngredientModel deleteIngredientModel)
        {
            //check if the ingredient is null
            if (await ingredientService
                .GetIngredientById(deleteIngredientModel.IngredientId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await ingredientService
                    .Delete(deleteIngredientModel.IngredientId);

                TempData["message"] = $"You have successfully deleted a ingredient!";

                return RedirectToAction("AllIngredients", "Ingredient");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(deleteIngredientModel);
            }
        }

        [Authorize(Roles = "ProductUser, Admin")]
        public async Task<IActionResult> IngredientSmoothies(int id)
        {
            //check if the ingredient is null
            if (await ingredientService
                .GetIngredientById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var smoothies = await ingredientService.GetSmoothiesByIngredient(id);

                return View(smoothies);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return RedirectToAction("AllIngredients", "Ingredient", new { area = "" });
            }
        }

    }
}

