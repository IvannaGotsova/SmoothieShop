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
            throw new NotImplementedException();
        }
    }
}
