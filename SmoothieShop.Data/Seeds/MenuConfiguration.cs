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
                   ProductUserId = 1,
                   Price = 10
                },            
            };

            return menus;
        }
    }
}
