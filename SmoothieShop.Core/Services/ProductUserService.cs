using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.ProductUserModels;
using SmoothieShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Services
{
    /// <summary>
    /// Holds Service for ProductUser functionality.
    /// </summary>
    public class ProductUserService : IProductUserService
    {
        private readonly IRepository data;

        public ProductUserService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method is used to add a productUser.
        /// </summary>
        /// <param name="addProductUserModel"></param>
        /// <returns></returns>
        public async Task Add(AddProductUserModel addProductUserModel)
        {
            var productUserToBeAdded = new ProductUser()
            {
                ApplicationUserId = addProductUserModel.ApplicationUserId,
            };

            await this.data.AddAsync(productUserToBeAdded);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method deletes a particular productUser with a given id.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        public async Task Delete(int productUserId)
        {
            await this.data.DeleteAsync<ProductUser>(productUserId);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a productUser.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        public async Task<DeleteProductUserModel> DeleteProductUserForm(int productUserId)
        {
            var productUserToBeDeleted = await
                GetProductUserById(productUserId);

            var deleteProductUserModel = new DeleteProductUserModel()
            {
                ProductUserId = productUserToBeDeleted.ProductUserId,
                ApplicationUserId = productUserToBeDeleted.ApplicationUserId
            };

            return deleteProductUserModel;
        }
        /// <summary>
        /// This method is used to edit a particular productUser with a given id.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <param name="editProductUserModel"></param>
        /// <returns></returns>
        public async Task Edit(int productUserId, EditProductUserModel editProductUserModel)
        {
            var productUserToBeEdited = await
               GetProductUserById(productUserId);

            productUserToBeEdited.ApplicationUserId = editProductUserModel.ApplicationUserId;

            this.data.Update<ProductUser>(productUserToBeEdited);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for editing a productUser.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        public async Task<EditProductUserModel> EditCreateForm(int productUserId)
        {
            var productUserToBeEdited = await
                 GetProductUserById(productUserId);

            var editProductUserModel = new EditProductUserModel()
            {
                ApplicationUserId = productUserToBeEdited.ApplicationUserId
            };

            return editProductUserModel;
        }
        /// <summary>
        /// This method returns IEnumerable of all productUsers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllProductUsersModel>> GetAllProductUsers()
        {
            var productUsers = await data
                 .AllReadonly<ProductUser>()
                 .ToListAsync();
                 

            return productUsers
                .Select(pu => new AllProductUsersModel()
                {
                    ProductUserId = pu.ProductUserId,
                    ApplicationUserId = pu.ApplicationUserId

                })
                .ToList();
        }
        /// <summary>
        /// This method returns a particular productUser with a given id.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        public async Task<ProductUser> GetProductUserById(int productUserId)
        {
            var productUser = await
              this.data
              .AllReadonly<ProductUser>()
              .Where(pu => pu.ProductUserId == productUserId)
              .FirstOrDefaultAsync();

            //check if productUser is null
            if (productUser == null)
            {
                throw new ArgumentNullException(null, nameof(productUser));
            }

            return productUser;
        }
        /// <summary>
        /// This method returns Details of particular productUser with a given id.
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns></returns>
        public async Task<DetailsProductUserModel> GetProductUserDetailsById(int productUserId)
        {
            var productUser = await
               this.data
               .AllReadonly<ProductUser>()
               //.Include(pu => pu.Menus)
               .Where(pu => pu.ProductUserId == productUserId)
               .Select(pu => new DetailsProductUserModel()
               {
                   ProductUserId = pu.ProductUserId,
                   ApplicationUserId = pu.ApplicationUserId,
                   MenusCount = pu.Menus.Count()
               }).FirstOrDefaultAsync();

            //check if productUser is null
            if (productUser == null)
            {
                throw new ArgumentNullException(null, nameof(productUser));
            }

            return productUser;
        }
        /// <summary>
        /// This method returns IEnumerable of all productUsers used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductUser>> GetProductUsersForSelect()
        {
            return await
                this.data
                .AllReadonly<ProductUser>()
                .ToListAsync();
        }
    }
}
