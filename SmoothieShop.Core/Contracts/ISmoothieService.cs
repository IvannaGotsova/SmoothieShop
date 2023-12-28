﻿using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.SmoothieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for Smoothie functionality.
    /// </summary>
    public interface ISmoothieService
    {
        /// <summary>
        /// This method returns IEnumerable of all smoothies.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllSmoothiesModel>> GetAllSmoothies();
        /// <summary>
        /// This method is used to add a smoothie.
        /// </summary>
        /// <param name="addSmoothieModel"></param>
        /// <returns></returns>
        Task Add(AddSmoothieModel addSmoothieModel);
        /// <summary>
        /// This method returns IEnumerable of all smoothies used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Smoothie>> GetSmoothiesForSelect();
        /// <summary>
        /// This method returns Details of particular smoothie with a given id.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        Task<DetailsSmoothieModel> GetSmoothieDetailsById(int smoothieId);
        /// <summary>
        /// This method creates form for editing a smoothie.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        Task<EditSmoothieModel> EditCreateForm(int smoothieId);
        /// <summary>
        /// This method is used to edit a particular smoothie with a given id.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <param name="editSmoothieModel"></param>
        /// <returns></returns>
        Task Edit(int smoothieId, EditSmoothieModel editSmoothieModel);
        /// <summary>
        /// This method returns a particular smoothie with a given id.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        Task<Smoothie> GetSmoothieById(int smoothieId);
        /// <summary>
        /// This method creates form for deleting a smoothie.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        Task<DeleteSmoothieModel> DeleteSmoothieForm(int smoothieId);
        /// <summary>
        /// This method deletes a particular smoothie with a given id.
        /// </summary>
        /// <param name="smoothieId"></param>
        /// <returns></returns>
        Task Delete(int smoothieId);
    }
}
