﻿using Microsoft.EntityFrameworkCore;
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
    /// Holds ProductUser Configuration.
    /// </summary>
    internal class ProductUserConfiguration : IEntityTypeConfiguration<ProductUser>
    {
        public void Configure(EntityTypeBuilder<ProductUser> builder)
        {
            builder.HasData(CreateProductsUsers());
        }

        // A method used to seed DB with initial data of productusers.
        private static List<ProductUser> CreateProductsUsers()
        {
            var productUsers = new List<ProductUser>()
            {
                new ProductUser()
                {
                   ProductUserId = 1,
                   ApplicationUserId = "productUser@product.com"
                },

            };

            return productUsers;
        }
    }
}
