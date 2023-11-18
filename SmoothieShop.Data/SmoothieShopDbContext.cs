using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmoothieShop.Data
{
    public class SmoothieShopDbContext : IdentityDbContext
    {
        public SmoothieShopDbContext(DbContextOptions<SmoothieShopDbContext> options)
            : base(options)
        {
        }
    }
}