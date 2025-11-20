using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.SearchModels;
using SmoothieShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly IRepository data;

        public SearchService(IRepository data)
        {
            this.data = data;
        }
        public SearchResultModel Search(string query)
        {

            var smoothies = data
                .AllReadonly<Smoothie>()
                .Where(s => s.SmoothieName.Contains(query))
                .ToList();

            var menus = data
                .AllReadonly<Menu>()
                .Where(m => m.MenuName.Contains(query))
                .ToList();

            var ingredients = data
                 .AllReadonly<Ingredient>()
                 .Where(i => i.IngredientName.Contains(query) || i.IngredientInfo.Contains(query))
                 .ToList();

            var feedbacks = data
                 .AllReadonly<Feedback>()
                 .Where(f => f.Comment.Contains(query) || f.Rating.ToString().Contains(query))
                 .ToList();

            var customers = data
                .AllReadonly<Customer>()
                .Where(c => c.FirstName.Contains(query) || c.LastName.Contains(query) || c.Address.Contains(query) || c.Email.Contains(query) || c.PhoneNumber.Contains(query))
                .ToList();

            var orders = data
                 .AllReadonly<Order>()
                 .Where(o => o.OrderId.ToString().Contains(query))
                 .ToList();

            var applicationUsers = data
                .AllReadonly<ApplicationUser>()
                .Where(au => au.UserName.Contains(query))
                .ToList();

            var customerUsers = data
                .AllReadonly<CustomerUser>()
                .Include( cu => cu.ApplicationUser)
                .Where(cu => cu.ApplicationUser.UserName.Contains(query))
                .ToList();

            var productUsers = data
                .AllReadonly<ProductUser>()
                 .Include(pu => pu.ApplicationUser)
                .Where(pu => pu.ApplicationUser.UserName.Contains(query))
                .ToList();


            return new SearchResultModel
            {
                Smoothies = smoothies,
                Menus = menus,
                Ingredients = ingredients,
                Feedbacks = feedbacks,
                Customers = customers,
                Orders = orders,
                ApplicationUsers = applicationUsers,
                CustomerUsers = customerUsers,
                ProductUsers = productUsers

            };
        }
    }
}
