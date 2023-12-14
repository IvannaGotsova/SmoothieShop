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
            throw new NotImplementedException();
        }
    }
}
