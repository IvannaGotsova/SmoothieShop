using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Models.IngredientModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    [Authorize(Roles = "ProductUser, Admin")]
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
                var editFormModel = await
               ingredientService
               .DeleteIngredientForm(id);

                return View(editFormModel);
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

    }
}

