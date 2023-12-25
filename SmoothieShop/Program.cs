using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmoothieShop.Data;
using SmoothieShop.Core;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Repositories;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Core.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SmoothieShopDbContext>
    (options => {
        options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SmoothieShop.Data"));
        options.UseSqlServer(connectionString);
    });

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>
    (
    options => {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = true;
        options.User.RequireUniqueEmail = true;

    })
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<SmoothieShopDbContext>();

builder.Services.AddControllersWithViews(
    options => {
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/ApplicationUsers/Login";
});

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerUserService, CustomerUserService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductUserService, ProductUserService>();
builder.Services.AddScoped<ISmoothieService, SmoothieService>();

builder.Services.AddMemoryCache();

var app = builder.Build();

//app.SeedUsersRoles();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );



    app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
    );

});

app.MapRazorPages();

app.Run();