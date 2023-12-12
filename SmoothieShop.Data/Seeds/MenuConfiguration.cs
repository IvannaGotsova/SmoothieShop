using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Seeds
{
    /// <summary>
    /// Holds Menu Configuration.
    /// </summary>
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(CreateMenus());
        }

        // A method used to seed DB with initial data of menus.
        private static List<Menu> CreateMenus()
        {
            var menus = new List<Menu>()
            {
                new Menu()
                {
                   MenuId = 1,
                   MenuName = "Basic",
                   Smoothies = new List<Smoothie>(){
                                                new Smoothie()
                                                {
                                                SmoothieId = 1,
                                                Name = "Banana Smoothie",
                                                Ingredients = new List<Ingredient>(){
                                                                            new Ingredient  { IngredientId = 1,
                                                                                              Name = "Banana",
                                                                                              Calories = 105,
                                                                                              IngredientInfo = "Bananas are berries, not   fruits."} },
                                                Size = 250,
                                                Price = 4.50M,
                                                Calories = 210, //to make a method to calculate automatically
                                                MenuId = 1,
                                                OrderId = 1,
                                                },

                                                new Smoothie()
                                                {
                                                SmoothieId = 2,
                                                Name = "Strawberry Smoothie",
                                                Ingredients = new List<Ingredient>(){
                                                                             new Ingredient  { IngredientId = 3,
                                                                                               Name = "Strawberry",
                                                                                               Calories = 32,
                                                                                               IngredientInfo = "Strawberries are not actually berries, but rather an accessory fruit."} },
                                                Size = 250,
                                                Price = 5.50M,
                                                Calories =  480, //to make a method to calculate automatically
                                                MenuId = 1,
                                                OrderId = 2,
                                                },
                   }
                },            
            };

            return menus;
        }
    }
}
