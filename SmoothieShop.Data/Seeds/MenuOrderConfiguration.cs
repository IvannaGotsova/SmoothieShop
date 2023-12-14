using Microsoft.EntityFrameworkCore;
using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Seeds
{
    /// <summary>
    /// Holds MenuOrder Configuration.
    /// </summary>
    internal class MenuOrderConfiguration : IEntityTypeConfiguration<MenuOrder>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MenuOrder> builder)
        {
            builder.HasData(CreateMenuOrders());
        }

        // A method used to seed DB with initial data of MenuOrders.
        private static List<MenuOrder> CreateMenuOrders()
        {
            var menuOrders = new List<MenuOrder>()
            {
                new MenuOrder()
                {
                   MenuId = 1,
                   OrderId = 1
                },

                 new MenuOrder()
                {
                   MenuId = 1,
                   OrderId = 2
                },
            };

            return menuOrders;
        }
    }
}
