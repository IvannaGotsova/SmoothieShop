using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    IngredientInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Smoothies",
                columns: table => new
                {
                    SmoothieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmoothieName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smoothies", x => x.SmoothieId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerUsers",
                columns: table => new
                {
                    CustomerUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerUsers", x => x.CustomerUserId);
                    table.ForeignKey(
                        name: "FK_CustomerUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductUsers",
                columns: table => new
                {
                    ProductUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUsers", x => x.ProductUserId);
                    table.ForeignKey(
                        name: "FK_ProductUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientSmoothie",
                columns: table => new
                {
                    IngredientsIngredientId = table.Column<int>(type: "int", nullable: false),
                    SmoothiesSmoothieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientSmoothie", x => new { x.IngredientsIngredientId, x.SmoothiesSmoothieId });
                    table.ForeignKey(
                        name: "FK_IngredientSmoothie_Ingredients_IngredientsIngredientId",
                        column: x => x.IngredientsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientSmoothie_Smoothies_SmoothiesSmoothieId",
                        column: x => x.SmoothiesSmoothieId,
                        principalTable: "Smoothies",
                        principalColumn: "SmoothieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientSmoothies",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    SmoothieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientSmoothies", x => new { x.IngredientId, x.SmoothieId });
                    table.ForeignKey(
                        name: "FK_IngredientSmoothies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientSmoothies_Smoothies_SmoothieId",
                        column: x => x.SmoothieId,
                        principalTable: "Smoothies",
                        principalColumn: "SmoothieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "CustomerUsers",
                        principalColumn: "CustomerUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_ProductUsers_ProductUserId",
                        column: x => x.ProductUserId,
                        principalTable: "ProductUsers",
                        principalColumn: "ProductUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSmoothie",
                columns: table => new
                {
                    MenusMenuId = table.Column<int>(type: "int", nullable: false),
                    SmoothiesSmoothieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSmoothie", x => new { x.MenusMenuId, x.SmoothiesSmoothieId });
                    table.ForeignKey(
                        name: "FK_MenuSmoothie_Menus_MenusMenuId",
                        column: x => x.MenusMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSmoothie_Smoothies_SmoothiesSmoothieId",
                        column: x => x.SmoothiesSmoothieId,
                        principalTable: "Smoothies",
                        principalColumn: "SmoothieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSmoothies",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    SmoothieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSmoothies", x => new { x.MenuId, x.SmoothieId });
                    table.ForeignKey(
                        name: "FK_MenuSmoothies_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSmoothies_Smoothies_SmoothieId",
                        column: x => x.SmoothieId,
                        principalTable: "Smoothies",
                        principalColumn: "SmoothieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuOrder",
                columns: table => new
                {
                    MenusMenuId = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuOrder", x => new { x.MenusMenuId, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_MenuOrder_Menus_MenusMenuId",
                        column: x => x.MenusMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                        //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuOrder_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                       //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuOrders",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuOrders", x => new { x.MenuId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_MenuOrders_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                    //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderSmoothie",
                columns: table => new
                {
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false),
                    SmoothiesSmoothieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSmoothie", x => new { x.OrdersOrderId, x.SmoothiesSmoothieId });
                    table.ForeignKey(
                        name: "FK_OrderSmoothie_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSmoothie_Smoothies_SmoothiesSmoothieId",
                        column: x => x.SmoothiesSmoothieId,
                        principalTable: "Smoothies",
                        principalColumn: "SmoothieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderSmoothies",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SmoothieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSmoothies", x => new { x.OrderId, x.SmoothieId });
                    table.ForeignKey(
                        name: "FK_OrderSmoothies_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSmoothies_Smoothies_SmoothieId",
                        column: x => x.SmoothieId,
                        principalTable: "Smoothies",
                        principalColumn: "SmoothieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin@admin.com", 0, "a0c1621d-e5af-4a36-a183-da319abbccb8", "admin@admin.com", false, "Ivan", "Ivanov", false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEMH48+D6AllfN8L9oQCwZWVCHfSqbU9/I5+o7CycsJDTFDj9FF/Z67cIj5opJ3MnhQ==", null, false, "2ddb4c08-798d-4e46-83f2-9328aaa91003", false, "admin@admin.com" },
                    { "customerUser@customer.com", 0, "e50d5ddf-1d33-4c7f-8105-48806751877d", "customerUser@customer.com", false, "Yordan", "Yordanov", false, null, "customerUser@customer.com", "customerUser@customer.com", "AQAAAAEAACcQAAAAEFnen7B2VhzL7KKTfKrSDyDibAjCSuKcIhlfT5tijbYk5O/ncz+6ljCJQYJX79HpDA==", null, false, "0a3656ee-846b-47c8-a97f-2233fe7b01a0", false, "customerUser@customer.com" },
                    { "guest1@guest.com", 0, "c0b3fbaf-01c4-4eca-8e9d-1a22d62e4a0f", "guest1@guest.com", false, "Petar", "Petrov", false, null, "guest1@guest.com", "guest1@guest.com", "AQAAAAEAACcQAAAAEG1vleKKMHVk0zakDZ8ht/T1aHm388yikSXIC+i75LQOGXpdYNEBgUrSJYSRuTyJOQ==", null, false, "63d13704-ac4f-4d99-9f9c-d608460fb805", false, "guest1@guest.com" },
                    { "guest2@guest.com", 0, "801f1274-729b-4c1f-be7b-1434ea65d03c", "guest2@guest.com", false, "Dimitar", "Dimitrov", false, null, "guest2@guest.com", "guest2@guest.com", "AQAAAAEAACcQAAAAEAxOs3YZ8LW1h6aYeLsGZllwBzJeC808zaoc/PoF4ucAvz41xwv/URdgTiiQAzFFvQ==", null, false, "84c8866f-853d-48de-a4ed-e999de09f6a5", false, "guest2@guest.com" },
                    { "productUser@product.com", 0, "b9ca09ce-1b5f-48b6-a140-cff5fe16d2fb", "productUser@product.com", false, "Stoqn", "Stoqnov", false, null, "productUser@product.com", "productUser@product.com", "AQAAAAEAACcQAAAAEJLifgbh2C342b7DXNl+repjwAA0KlSewliA0RSL4zeKnIcCUZy06V4xjl35ULJ5YA==", null, false, "f96d3be5-998a-46ff-a719-b51926f9b37d", false, "productUser@product.com" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Calories", "IngredientInfo", "IngredientName" },
                values: new object[,]
                {
                    { 1, 105.0, "Bananas are berries, not fruits.", "Banana" },
                    { 2, 42.0, "Kiwis are a type of berry and are related to strawberries and raspberries.", "Kiwi" },
                    { 3, 32.0, "Strawberries are not actually berries, but rather an accessory fruit.", "Strawberry" }
                });

            migrationBuilder.InsertData(
                table: "Smoothies",
                columns: new[] { "SmoothieId", "Calories", "Price", "Size", "SmoothieName" },
                values: new object[,]
                {
                    { 1, 210.0, 4.50m, 250.0, "Banana Smoothie" },
                    { 2, 480.0, 5.50m, 250.0, "Strawberry Smoothie" }
                });

            migrationBuilder.InsertData(
                table: "CustomerUsers",
                columns: new[] { "CustomerUserId", "ApplicationUserId" },
                values: new object[] { 1, "customerUser@customer.com" });

            migrationBuilder.InsertData(
                table: "IngredientSmoothies",
                columns: new[] { "IngredientId", "SmoothieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductUsers",
                columns: new[] { "ProductUserId", "ApplicationUserId" },
                values: new object[] { 1, "productUser@product.com" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerUserId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "Bulgaria", 1, "guest1@guest.com", "Petar", "Petrov", "0000000000" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerUserId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, "Bulgaria", 1, "guest2@guest.com", "Dimitar", "Dimitrov", "0000000000" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "MenuName", "ProductUserId" },
                values: new object[] { 1, "Basic", 1 });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FeedbackId", "Comment", "CustomerId", "Rating" },
                values: new object[,]
                {
                    { 1, "That was great smoothie.", 1, 10 },
                    { 2, "That was amazing smoothie.", 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "MenuSmoothies",
                columns: new[] { "MenuId", "SmoothieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "Date", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.50m },
                    { 2, 2, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.50m }
                });

            migrationBuilder.InsertData(
                table: "MenuOrders",
                columns: new[] { "MenuId", "OrderId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderSmoothies",
                columns: new[] { "OrderId", "SmoothieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerUserId",
                table: "Customers",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_ApplicationUserId",
                table: "CustomerUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientSmoothie_SmoothiesSmoothieId",
                table: "IngredientSmoothie",
                column: "SmoothiesSmoothieId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientSmoothies_SmoothieId",
                table: "IngredientSmoothies",
                column: "SmoothieId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuOrder_OrdersOrderId",
                table: "MenuOrder",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuOrders_OrderId",
                table: "MenuOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ProductUserId",
                table: "Menus",
                column: "ProductUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSmoothie_SmoothiesSmoothieId",
                table: "MenuSmoothie",
                column: "SmoothiesSmoothieId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSmoothies_SmoothieId",
                table: "MenuSmoothies",
                column: "SmoothieId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSmoothie_SmoothiesSmoothieId",
                table: "OrderSmoothie",
                column: "SmoothiesSmoothieId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSmoothies_SmoothieId",
                table: "OrderSmoothies",
                column: "SmoothieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUsers_ApplicationUserId",
                table: "ProductUsers",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "IngredientSmoothie");

            migrationBuilder.DropTable(
                name: "IngredientSmoothies");

            migrationBuilder.DropTable(
                name: "MenuOrder");

            migrationBuilder.DropTable(
                name: "MenuOrders");

            migrationBuilder.DropTable(
                name: "MenuSmoothie");

            migrationBuilder.DropTable(
                name: "MenuSmoothies");

            migrationBuilder.DropTable(
                name: "OrderSmoothie");

            migrationBuilder.DropTable(
                name: "OrderSmoothies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Smoothies");

            migrationBuilder.DropTable(
                name: "ProductUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerUsers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
