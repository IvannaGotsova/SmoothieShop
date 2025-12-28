using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.IngredientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for Ingredient functionality.
    /// </summary>
    public interface IIngredientService
    {
        /// <summary>
        /// This method returns IEnumerable of all ingredients.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllIngredientsModel>> GetAllIngredients();
        /// <summary>
        /// This method is used to add a ingredient.
        /// </summary>
        /// <param name="addIngredientModel"></param>
        /// <returns></returns>
        Task Add(AddIngredientModel addIngredientModel);
        /// <summary>
        /// This method returns IEnumerable of all ingredients used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ingredient>> GetIngredientsForSelect();
        /// <summary>
        /// This method returns Details of particular ingredient with a given id.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<DetailsIngredientModel> GetIngredientDetailsById(int ingredientId);
        /// <summary>
        /// This method creates form for editing a ingredient.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<EditIngredientModel> EditCreateForm(int ingredientId);
        /// <summary>
        /// This method is used to edit a particular ingredient with a given id.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <param name="editIngredientModel"></param>
        /// <returns></returns>
        Task Edit(int ingredientId, EditIngredientModel editIngredientModel);
        /// <summary>
        /// This method returns a particular ingredient with a given id.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<Ingredient> GetIngredientById(int ingredientId);
        /// <summary>
        /// This method creates form for deleting a ingredient.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<DeleteIngredientModel> DeleteIngredientForm(int ingredientId);
        /// <summary>
        /// This method deletes a particular ingredient with a given id.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task Delete(int ingredientId);

        int Count();

        Task<IEnumerable<Smoothie>> GetSmoothiesByIngredient(int ingredientId);
    }
}
