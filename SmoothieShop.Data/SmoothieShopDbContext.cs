using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Seeds;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SmoothieShop.Data
{
    /// <summary>
    /// Holds SmoothieShop DbContext.
    /// </summary>
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
        /// <summary>
        /// Holds DbSets of the app.
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerUser> CustomerUsers { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<ProductUser> ProductUsers { get; set; } = null!;
        public DbSet<Smoothie> Smoothies { get; set; } = null!;
        public DbSet<MenuOrder> MenuOrders { get; set; } = null!;
        public DbSet<MenuSmoothie> MenuSmoothies { get; set; } = null!;
        /// <summary>
        /// Holds OnModelCreating functionality.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.Id)
                .HasDefaultValueSql("newid()");

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

            builder
                .Entity<MenuOrder>()
                .HasKey(mo => new { mo.MenuId, mo.OrderId });

            builder
                .Entity<MenuSmoothie>()
                .HasKey(ms => new { ms.MenuId, ms.SmoothieId });
               

            /// <summary>
            /// Holds Configurations of the app.
            /// </summary>
            if (this.seedDb)
            {
                builder.ApplyConfiguration(new ApplicationUserConfiguration());
                builder.ApplyConfiguration(new CustomerConfiguration());
                builder.ApplyConfiguration(new CustomerUserConfiguration());
                builder.ApplyConfiguration(new FeedbackConfiguration());
                builder.ApplyConfiguration(new IngredientConfiguration());
                builder.ApplyConfiguration(new MenuConfiguration());
                builder.ApplyConfiguration(new OrderConfiguration());
                builder.ApplyConfiguration(new ProductUserConfiguration());
                builder.ApplyConfiguration(new SmoothieConfiguration());
                builder.ApplyConfiguration(new MenuOrderConfiguration());
                builder.ApplyConfiguration(new MenuSmoothieConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}