using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmoothieShop.Data.Seeds
{
    /// <summary>
    /// Holds Smoothie Configuration.
    /// </summary>
    internal class SmoothieConfiguration : IEntityTypeConfiguration<Smoothie>
    {
        public void Configure(EntityTypeBuilder<Smoothie> builder)
        {
            builder.HasData(CreateSmoothies());
        }

        // A method used to seed DB with initial data of smoothies.
        private static List<Smoothie> CreateSmoothies()
        {
            var smoothies = new List<Smoothie>()
            {
                new Smoothie()
                {
                   SmoothieId = 1,
                   Name = "Banana Smoothie",
                   Ingredients = new List<Ingredient>(){
                                                      new Ingredient  { IngredientId = 1,
                                                                        Name = "Banana",
                                                                        Calories = 105,
                                                                        IngredientInfo = "Bananas are berries, not fruits."} },
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
            };

            return smoothies;
        }
    }
}
