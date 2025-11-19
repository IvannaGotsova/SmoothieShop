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
            var ingredients = data
                .AllReadonly<Ingredient>()
                .Where(i => i.IngredientName.Contains(query) || i.IngredientInfo.Contains(query))
                .ToList();

            var smoothies = data
                .AllReadonly<Smoothie>()
                .Where(s => s.SmoothieName.Contains(query))
                .ToList();

            var menus = data
                .AllReadonly<Menu>()
                .Where(m => m.MenuName.Contains(query))
                .ToList();

            return new SearchResultModel
            {
                Ingredients = ingredients,
                Smoothies = smoothies,
                Menus = menus
            };
        }
    }
}
