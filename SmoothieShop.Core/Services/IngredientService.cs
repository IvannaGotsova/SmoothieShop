using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.IngredientModels;
using SmoothieShop.Data.Models.SmoothieModels;
using SmoothieShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Services
{
    /// <summary>
    /// Holds Service for Ingredient functionality.
    /// </summary>
    public class IngredientService : IIngredientService
    {
        private readonly IRepository data;

        public IngredientService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method is used to add a ingredient.
        /// </summary>
        /// <param name="addIngredientModel"></param>
        /// <returns></returns>
        public async Task Add(AddIngredientModel addIngredientModel)
        {
            var ingredientToBeAdded = new Ingredient()
            {
                IngredientInfo = addIngredientModel.IngredientInfo,
                IngredientName = addIngredientModel.IngredientName,
                Calories = addIngredientModel.Calories
            };

            await this.data.AddAsync(ingredientToBeAdded);
            await this.data.SaveChangesAsync();
        }

        public int Count()
        {
            return
                this.data
                .AllReadonly<Ingredient>()
                .Count();
        }

        /// <summary>
        /// This method deletes a particular feddback with a given id.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public async Task Delete(int ingredientId)
        {
            var smoothiesIngredients = await
                this.data
                .AllReadonly<IngredientSmoothie>()
                .Where(ism => ism.IngredientId == ingredientId)
                .ToListAsync();

            this.data.RemoveRange(smoothiesIngredients);

            await this.data.DeleteAsync<Ingredient>(ingredientId);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a ingredient.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public async Task<DeleteIngredientModel> DeleteIngredientForm(int ingredientId)
        {
            var ingredientToBeDeleted = await
                GetIngredientById(ingredientId);

            var deleteIngredientModel = new DeleteIngredientModel()
            {
                IngredientId = ingredientToBeDeleted.IngredientId,
                IngredientInfo = ingredientToBeDeleted.IngredientInfo,
                IngredientName = ingredientToBeDeleted.IngredientName,
                Calories = ingredientToBeDeleted.Calories
            };

            return deleteIngredientModel;
        }
        /// <summary>
        /// This method is used to edit a particular ingredient with a given id.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <param name="editIngredientModel"></param>
        /// <returns></returns>
        public async Task Edit(int ingredientId, EditIngredientModel editIngredientModel)
        {
            var ingredientToBeEdited = await
                GetIngredientById(ingredientId);

            ingredientToBeEdited.IngredientInfo = editIngredientModel.IngredientInfo;
            ingredientToBeEdited.IngredientName = editIngredientModel.IngredientName;
            ingredientToBeEdited.Calories = editIngredientModel.Calories;

            this.data.Update<Ingredient>(ingredientToBeEdited);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for editing a ingredient.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public async Task<EditIngredientModel> EditCreateForm(int ingredientId)
        {
            var ingredientToBeEdited = await
                  GetIngredientById(ingredientId);

            var editIngredientModel = new EditIngredientModel()
            {
                IngredientInfo = ingredientToBeEdited.IngredientInfo,
                IngredientName = ingredientToBeEdited.IngredientName,
                Calories = ingredientToBeEdited.Calories,
            };

            return editIngredientModel;
        }
        /// <summary>
        /// This method returns IEnumerable of all ingredients.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllIngredientsModel>> GetAllIngredients()
        {
            var ingredients = await data
                .AllReadonly<Ingredient>()
                .ToListAsync();


            return ingredients
                .Select(i => new AllIngredientsModel()
                {
                    IngredientId = i.IngredientId,
                    IngredientName = i.IngredientName,
                    IngredientInfo = i.IngredientInfo,
                    Calories = i.Calories
                })
                .ToList();
        }
        /// <summary>
        /// This method returns a particular ingredient with a given id.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public async Task<Ingredient> GetIngredientById(int ingredientId)
        {
            var ingredient = await
               this.data
               .AllReadonly<Ingredient>()
               .Where(f => f.IngredientId == ingredientId)
               .FirstOrDefaultAsync();

            //check if customer is null
            if (ingredient == null)
            {
                throw new ArgumentNullException(null, nameof(ingredient));
            }

            return ingredient;
        }
        /// <summary>
        /// This method returns Details of particular ingredient with a given id.
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public async Task<DetailsIngredientModel> GetIngredientDetailsById(int ingredientId)
        {
            var ingredient = await
               this.data
               .AllReadonly<Ingredient>()
               .Include(i => i.Smoothies)
               .Where(i => i.IngredientId == ingredientId)
               .Select(i => new DetailsIngredientModel()
               {
                   IngredientId = i.IngredientId,
                   IngredientName = i.IngredientName,
                   IngredientInfo = i.IngredientInfo,
                   Calories = i.Calories
               }).FirstOrDefaultAsync();

            //check if customer is null
            if (ingredient == null)
            {
                throw new ArgumentNullException(null, nameof(ingredient));
            }

            return ingredient;
        }
        /// <summary>
        /// This method returns IEnumerable of all ingredients used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Ingredient>> GetIngredientsForSelect()
        {
            return await
                this.data
                .AllReadonly<Ingredient>()
                .ToListAsync();
        }

        public async Task<IEnumerable<Smoothie>> GetSmoothiesByIngredient(int ingredientId)
        {
            var smoothies = await data
                .AllReadonly<IngredientSmoothie>()
                .Where(ism => ism.IngredientId == ingredientId)
                .Select(ism => ism.Smoothie)
                .ToListAsync();

            return smoothies;
        }
    }
}

