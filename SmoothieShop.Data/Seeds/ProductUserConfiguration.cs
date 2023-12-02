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
    /// Holds ProductUser Configuration.
    /// </summary>
    internal class ProductUserConfiguration : IEntityTypeConfiguration<ProductUser>
    {
        public void Configure(EntityTypeBuilder<ProductUser> builder)
        {
            throw new NotImplementedException();
        }
    }
}
