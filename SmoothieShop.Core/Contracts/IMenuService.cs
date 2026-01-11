using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.MenuModels;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for Menu functionality.
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// This method returns IEnumerable of all menus.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllMenusModel>> GetAllMenus();
        /// <summary>
        /// This method is used to add a menu.
        /// </summary>
        /// <param name="addMenuModel"></param>
        /// <returns></returns>
        Task Add(AddMenuModel addMenuModel);
        /// <summary>
        /// This method returns IEnumerable of all menus used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Menu>> GetMenusForSelect();
        /// <summary>
        /// This method returns Details of particular menu with a given id.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task<DetailsMenuModel> GetMenuDetailsById(int menuId);
        /// <summary>
        /// This method creates form for editing a menu.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task<EditMenuModel> EditCreateForm(int menuId);
        /// <summary>
        /// This method is used to edit a particular menu with a given id.
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="editMenuModel"></param>
        /// <returns></returns>
        Task Edit(int menuId, EditMenuModel editMenuModel);
        /// <summary>
        /// This method returns a particular menu with a given id.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task<Menu> GetMenuById(int menuId);
        /// <summary>
        /// This method creates form for deleting a menu.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task<DeleteMenuModel> DeleteMenuForm(int menuId);
        /// <summary>
        /// This method deletes a particular menu with a given id.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task Delete(int menuId);
        /// <summary>
        /// This method returns count of all Menus.
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// This method gets smoothies by menu.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task<IEnumerable<Smoothie>> GetSmoothiesByMenu(int menuId);
        /// <summary>
        /// This method gets orders by menu.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetOrdersByMenu(int menuId);
        /// <summary>
        /// This method gets smoothies Ids by menu.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task<IEnumerable<int>> GetSmoothiesIdsByMenu(int menuId);
        /// <summary>
        /// This method gets all menus by customer ID.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<IEnumerable<Menu>> GetAllMenusByCustomer(int customerId);
    }
}
