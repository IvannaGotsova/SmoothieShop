using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
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
    /// Holds Service for Smoothie functionality.
    /// </summary>
    public class SmoothieService : ISmoothieService
    {
        private readonly IRepository data;

        public SmoothieService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method is used to add a smoothie.
        /// </summary>
        /// <param name="addSmoothieModel"></param>
        /// <returns></returns>
        public async Task Add(AddSmoothieModel addSmoothieModel)
        {
            var smoothieToBeAdded = new Smoothie()
            {
                SmoothieName = addSmoothieModel.SmoothieName,
                Price = addSmoothieModel.Price,
                Size = addSmoothieModel.Size,
                Calories = addSmoothieModel.Calories,
            };

            await this.data.AddAsync(smoothieToBeAdded);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method deletes a particular smoothie with a given id.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        public async Task Delete(int smoothieId)
        {
            await this.data.DeleteAsync<Smoothie>(smoothieId);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a smoothie.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        public async Task<DeleteSmoothieModel> DeleteSmoothieForm(int smoothieId)
        {
            var smoothieToBeDeleted = await
                GetSmoothieById(smoothieId);

            var deleteSmoothieModel = new DeleteSmoothieModel()
            {
                SmoothieId = smoothieToBeDeleted.SmoothieId,
                SmoothieName = smoothieToBeDeleted.SmoothieName,
                Price = smoothieToBeDeleted.Price,
                Size = smoothieToBeDeleted.Size,
                Calories = smoothieToBeDeleted.Calories,
            };

            return deleteSmoothieModel;
        }
        /// <summary>
        /// This method is used to edit a particular smoothie with a given id.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <param name="editSmoothieModel"></param>
        /// <returns></returns>
        public async Task Edit(int smoothieId, EditSmoothieModel editSmoothieModel)
        {
            var smoothieToBeEdited = await
                GetSmoothieById(smoothieId);

            smoothieToBeEdited.SmoothieName = editSmoothieModel.SmoothieName;
            smoothieToBeEdited.Size = editSmoothieModel.Size;
            smoothieToBeEdited.Price = editSmoothieModel.Price;
            smoothieToBeEdited.Calories = editSmoothieModel.Calories;

            this.data.Update<Smoothie>(smoothieToBeEdited);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for editing a smoothie.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        public async Task<EditSmoothieModel> EditCreateForm(int smoothieId)
        {
            var smoothieToBeEdited = await
                 GetSmoothieById(smoothieId);

            var editSmoothieModel = new EditSmoothieModel()
            {
                SmoothieName = smoothieToBeEdited.SmoothieName,
                Size = smoothieToBeEdited.Size,
                Price = smoothieToBeEdited.Price,
                Calories = smoothieToBeEdited.Calories,
            };

            return editSmoothieModel;
        }
        /// <summary>
        /// This method returns IEnumerable of all smoothies.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllSmoothiesModel>> GetAllSmoothies()
        {
            var smoothies = await data
                .AllReadonly<Smoothie>()
                .ToListAsync();

            return smoothies
                .Select(s => new AllSmoothiesModel()
                {
                    SmoothieId = s.SmoothieId,
                    SmoothieName = s.SmoothieName,
                    Size = s.Size,
                    Price = s.Price,
                    Calories = s.Calories,
                })
                .ToList();
        }
        /// <summary>
        /// This method returns a particular smoothie with a given id.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        public async Task<Smoothie> GetSmoothieById(int smoothieId)
        {
            var smoothie = await
               this.data
               .AllReadonly<Smoothie>()
               .Where(c => c.SmoothieId == smoothieId)
               .FirstOrDefaultAsync();

            //check if smoothie is null
            if (smoothie == null)
            {
                throw new ArgumentNullException(null, nameof(smoothie));
            }

            return smoothie;
        }
        /// <summary>
        /// This method returns Details of particular smoothie with a given id.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        public async Task<DetailsSmoothieModel> GetSmoothieDetailsById(int smoothieId)
        {
            var smoothie = await
               this.data
               .AllReadonly<Smoothie>()
               .Include(s => s.Orders)
               .Include(s => s.Menus)
               .Include(s => s.Ingredients)
               .Where(s => s.SmoothieId == smoothieId)
               .Select(s => new DetailsSmoothieModel()
               {
                   SmoothieId = s.SmoothieId,
                   SmoothieName = s.SmoothieName,
                   Size = s.Size,
                   Calories = s.Calories,
                   OrdersCount = s.Orders.Count(),
                   MenusCount = s.Menus.Count(),
                   IngredientsCount = s.Ingredients.Count()
               }).FirstOrDefaultAsync();

            //check if smoothie is null
            if (smoothie == null)
            {
                throw new ArgumentNullException(null, nameof(smoothie));
            }

            return smoothie;
        }
        /// <summary>
        /// This method returns IEnumerable of all smoothies used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Smoothie>> GetSmoothiesForSelect()
        {
            return await
                this.data
                .AllReadonly<Smoothie>()
                .ToListAsync();
        }
    }
}

