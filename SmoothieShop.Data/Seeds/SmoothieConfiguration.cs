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
    internal class SmoothieConfiguration : IEntityTypeConfiguration<Smoothie>
    {
        public void Configure(EntityTypeBuilder<Smoothie> builder)
        {
            throw new NotImplementedException();
        }
    }
}
