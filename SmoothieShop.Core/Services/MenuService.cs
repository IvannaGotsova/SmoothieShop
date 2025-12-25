using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.MenuModels;
using SmoothieShop.Data.Models.OrderModels;
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
    /// Holds Service for Menu functionality.
    /// </summary>
    public class MenuService : IMenuService
    {
        private readonly IRepository data;

        public MenuService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method is used to add a menu.
        /// </summary>
        /// <param name="addMenuModel"></param>
        /// <returns></returns>
        public async Task Add(AddMenuModel addMenuModel)
        {
            var menuToBeAdded = new Menu()
            {
                MenuName = addMenuModel.MenuName,
                Price = addMenuModel.Price,
                Calories = addMenuModel.Calories,
            };

            await this.data.AddAsync(menuToBeAdded);

            foreach (var smoothie in addMenuModel.SmoothiesIds)
            {
                var smoothieMenuToBeAdded = new MenuSmoothie()
                {
                    SmoothieId = smoothie,
                    Menu = menuToBeAdded

                };

                await this.data.AddAsync(smoothieMenuToBeAdded);
            }

            await this.data.SaveChangesAsync();
        }

        public int Count()
        {
            return
                this.data
                .AllReadonly<Menu>()
                .Count();
        }

        /// <summary>
        /// This method deletes a particular menu with a given id.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task Delete(int menuId)
        {
            var smoothiesMenus = await
                this.data
                .AllReadonly<MenuSmoothie>()
                .Where(ms => ms.MenuId == menuId)
                .ToListAsync();

            this.data.RemoveRange(smoothiesMenus);

            await this.data.DeleteAsync<Menu>(menuId);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a menu.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task<DeleteMenuModel> DeleteMenuForm(int menuId)
        {
            var menuToBeDeleted = await
                GetMenuById(menuId);

            var deleteMenuModel = new DeleteMenuModel()
            {
                MenuId = menuToBeDeleted.MenuId,
                MenuName = menuToBeDeleted.MenuName
            };

            return deleteMenuModel;
        }
        /// <summary>
        /// This method is used to edit a particular menu with a given id.
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="editMenuModel"></param>
        /// <returns></returns>
        public async Task Edit(int menuId, EditMenuModel editMenuModel)
        {
            var menuToBeEdited = await
                GetMenuById(menuId);

            menuToBeEdited.MenuName = editMenuModel.MenuName;
            menuToBeEdited.Price = editMenuModel.Price;
            menuToBeEdited.Calories = editMenuModel.Calories;

            this.data.Update<Menu>(menuToBeEdited);

            var smoothiesMenusToDelete = await
              this.data
              .AllReadonly<MenuSmoothie>()
              .Where(ms => ms.MenuId == menuId)
              .ToListAsync();

            this.data.DeleteRange<MenuSmoothie>(smoothiesMenusToDelete);


            foreach (var smoothie in editMenuModel.SelectedSmoothiesIds)
            {
                var smoothiesMenusToBeEdited = new MenuSmoothie()
                {
                    SmoothieId = smoothie,
                    Menu = menuToBeEdited

                };

                await this.data.AddAsync(smoothiesMenusToBeEdited);
            }

            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for editing a menu.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task<EditMenuModel> EditCreateForm(int menuId)
        {
            var menuToBeEdited = await
                 GetMenuById(menuId);

            var editMenuModel = new EditMenuModel()
            {
                MenuName = menuToBeEdited.MenuName,
                Price = menuToBeEdited.Price,
                Calories = menuToBeEdited.Calories,
                SmoothiesIds = menuToBeEdited.MenusSmoothies.Select(ms => ms.MenuId).ToList(),
                SmoothiesMenus = new List<MenuSmoothie>()
            };

            return editMenuModel;
        }
        /// <summary>
        /// This method returns IEnumerable of all menus.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllMenusModel>> GetAllMenus()
        {
            var menus = await data
                .AllReadonly<Menu>()
                .ToListAsync();

            return menus
                .Select(m => new AllMenusModel()
                {
                    MenuId = m.MenuId,
                    MenuName = m.MenuName,
                    Price = m.Price,
                    Calories = m.Calories
                })
                .ToList();
        }
        /// <summary>
        /// This method returns a particular menu with a given id.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task<Menu> GetMenuById(int menuId)
        {
            var menu = await
               this.data
               .AllReadonly<Menu>()
               .Where(m => m.MenuId == menuId)
               .FirstOrDefaultAsync();

            //check if menu is null
            if (menu == null)
            {
                throw new ArgumentNullException(null, nameof(menu));
            }

            return menu;
        }
        /// <summary>
        /// This method returns Details of particular menu with a given id.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task<DetailsMenuModel> GetMenuDetailsById(int menuId)
        {
            var menu = await
               this.data
               .AllReadonly<Menu>()
               .Include(m => m.Orders)
               .Include(m => m.Smoothies)
               .Where(m => m.MenuId == menuId)
               .Select(m => new DetailsMenuModel()
               {
                   MenuId = m.MenuId,
                   MenuName = m.MenuName,
                   Price = m.Price,
                   Calories = m.Calories,
                   OrdersCount = m.Orders.Count(),
                   SmoothiesCount = m.Smoothies.Count(),
               }).FirstOrDefaultAsync();

            //check if menu is null
            if (menu == null)
            {
                throw new ArgumentNullException(null, nameof(menu));
            }

            return menu;
        }
        /// <summary>
        /// This method returns IEnumerable of all menus used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Menu>> GetMenusForSelect()
        {
            return await
                this.data
                .AllReadonly<Menu>()
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByMenu(int menuId)
        {
            var orders = await data
               .AllReadonly<MenuOrder>()
               .Where(mo => mo.MenuId == menuId)
               .Select(mo => mo.Order)
               .ToListAsync();

            return orders;
        }

        public async Task<IEnumerable<Smoothie>> GetSmoothiesByMenu(int menuId)
        {
            var smoothies = await data
                .AllReadonly<MenuSmoothie>()
                .Where(ms => ms.MenuId == menuId)
                .Select(ms => ms.Smoothie)
                .ToListAsync();

            return smoothies;
        }

        public async Task<IEnumerable<int>> GetSmoothiesIdsByMenu(int menuId)
        {
            var smoothiesIds = await data
                 .AllReadonly<MenuSmoothie>()
                 .Where(ms => ms.MenuId == menuId)
                 .Select(ms => ms.SmoothieId)
                 .ToListAsync();

            return smoothiesIds;
        }
    }
}
