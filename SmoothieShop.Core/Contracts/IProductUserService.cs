using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.MenuModels;
using SmoothieShop.Data.Models.ProductUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for ProductUser functionality.
    /// </summary>
    public interface IProductUserService
    {
        /// <summary>
        /// This method returns IEnumerable of all ProductUsers.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllProductUsersModel>> GetAllProductUsers();
        /// <summary>
        /// This method is used to add a productUser.
        /// </summary>
        /// <param name="addProductUserModel"></param>
        /// <returns></returns>
        Task Add(AddProductUserModel addProductUserModel);
        /// <summary>
        /// This method returns IEnumerable of all productUsers used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductUser>> GetProductUsersForSelect();
        /// <summary>
        /// This method returns Details of particular productUser with a given id.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        Task<DetailsProductUserModel> GetProductUserDetailsById(int productUserId);
        /// <summary>
        /// This method creates form for editing a productUser.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        Task<EditProductUserModel> EditCreateForm(int productUserId);
        /// <summary>
        /// This method is used to edit a particular productUser with a given id.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <param name="editProductUserModel"></param>
        /// <returns></returns>
        Task Edit(int productUserId, EditProductUserModel editProductUserModel);
        /// <summary>
        /// This method returns a particular productUser with a given id.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        Task<ProductUser> GetProductUserById(int productUserId);
        /// <summary>
        /// This method creates form for deleting a productUser.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        Task<DeleteProductUserModel> DeleteProductUserForm(int productUserId);
        /// <summary>
        /// This method deletes a particular productUser with a given id.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        Task Delete(int productUserId);

        int Count();

        Task<IEnumerable<DetailsMenuModel>> GetMenusByProductUserId(int productUserId);
    }
}
