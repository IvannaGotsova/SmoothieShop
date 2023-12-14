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
    /// Holds MenuSmoothie Configuration.
    /// </summary>
    internal class MenuSmoothieConfiguration : IEntityTypeConfiguration<MenuSmoothie>
    {
        public void Configure(EntityTypeBuilder<MenuSmoothie> builder)
        {
            builder.HasData(CreateMenuSmoothies());
        }

        // A method used to seed DB with initial data of MenuSmoothies.
        private static List<MenuSmoothie> CreateMenuSmoothies()
        {
            var menuSmoothies = new List<MenuSmoothie>()
            {
                new MenuSmoothie()
                {
                   MenuId = 1,
                   SmoothieId = 1
                },

                 new MenuSmoothie()
                {
                   MenuId = 1,
                   SmoothieId = 2
                },
            };

            return menuSmoothies;
        }
    }
}
