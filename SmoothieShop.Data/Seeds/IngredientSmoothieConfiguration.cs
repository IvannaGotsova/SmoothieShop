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
    /// Holds IngredientSmoothie Configuration.
    /// </summary>
    internal class IngredientSmoothieConfiguration : IEntityTypeConfiguration<IngredientSmoothie>
    {
        public void Configure(EntityTypeBuilder<IngredientSmoothie> builder)
        {
            builder.HasData(CreateIngredientSmoothies());
        }

        // A method used to seed DB with initial data of IngredientSmoothie.
        private static List<IngredientSmoothie> CreateIngredientSmoothies()
        {
            var ingredientSmoothies = new List<IngredientSmoothie>()
            {
                new IngredientSmoothie()
                {
                   IngredientId = 1,
                   SmoothieId = 1
                },

                 new IngredientSmoothie()
                {
                   IngredientId = 3,
                   SmoothieId = 2
                },
            };

            return ingredientSmoothies;
        }
    }
}
