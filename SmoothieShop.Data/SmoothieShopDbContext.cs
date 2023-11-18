using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmoothieShop.Data.Data.Entites;

namespace SmoothieShop.Data
{
    public class SmoothieShopDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly bool seedDb;

        public SmoothieShopDbContext(DbContextOptions<SmoothieShopDbContext> options, bool seed = true)
            : base(options)
        {
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
                this.seedDb = seed;
            }

            this.seedDb = seed;
        }

        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<CustomerUser> CustomerUser { get; set; } = null!;
        public DbSet<Feedback> Feedback { get; set; } = null!;
        public DbSet<Ingredient> Ingredient { get; set; } = null!;
        public DbSet<Menu> Menu { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<ProductUser> ProductUser { get; set; } = null!;
        public DbSet<Smoothie> Smoothie { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
               .Entity<ApplicationUser>()
               .Property(u => u.FirstName)
               .HasMaxLength(60)
               .IsRequired();

            builder
               .Entity<ApplicationUser>()
               .Property(u => u.LastName)
               .HasMaxLength(60)
               .IsRequired();



            base.OnModelCreating(builder);
        }
    }
}