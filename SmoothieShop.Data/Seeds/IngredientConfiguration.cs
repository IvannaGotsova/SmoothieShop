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
    /// Holds Ingredient Configuration.
    /// </summary>
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasData(CreateIngredients());
        }

        private static List<Ingredient> CreateIngredients()
        {
            var ingredients = new List<Ingredient>()
            {
                new Ingredient()
                {
                   IngredientId = 1,
                   Name = "Banana",
                   Calories = 105,
                   IngredientInfo = "Bananas are berries, not fruits."
                },

                new Ingredient()
                {
                  IngredientId = 2,
                  Name = "Kiwi",
                  Calories = 42,
                  IngredientInfo = "Kiwis are a type of berry and are related to strawberries and raspberries."
                },

                new Ingredient()
                {
                  IngredientId = 3,
                  Name = "Strawberry",
                  Calories = 32,
                  IngredientInfo = "Strawberries are not actually berries, but rather an accessory fruit."
                },
            };

            return ingredients;
        }
    }
}
