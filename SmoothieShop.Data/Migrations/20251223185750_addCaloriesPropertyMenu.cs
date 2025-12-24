using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class addCaloriesPropertyMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "Menus",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ad2ccbc-ef41-43eb-bf7c-b4c681e18010", "AQAAAAEAACcQAAAAEHbhlRvn1YOFOcyp7QdbAzBuL9kxjY2iHj/gXTLt/aVz3fmMwx8C/le9c74TT8ehjg==", "67c1fb8d-5621-48f4-816e-d9ca968736f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24b60f3a-842a-4623-ad6a-4b509bf2ec2a", "AQAAAAEAACcQAAAAEJIkzv7n2MIDkgG7gbR9ytZoPsY1wuVYiQmgfto7+m0+s3Di9QvYgOGgLTMWDKoKWA==", "fff44dee-5ab0-42e6-bbff-4d02ffacdd57" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b88e3fc-397f-482f-bcf0-b4777e6ab87c", "AQAAAAEAACcQAAAAEEStj2LpF9jXHm0GwCw2CLuAwG6pZy6ExpatqwS7m4pzyUMPbw3+L5nSglu27IXgew==", "8e1fec52-8033-4cb6-bf82-a5493ce4adaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1708355d-2c0d-44b9-a226-bf2b66bda734", "AQAAAAEAACcQAAAAEGAOiFU48ISkENgEFXwM+QX/gwXXmyEnTXplQKhm3OIXj5AzDEfEkWO4hME1pcQHUg==", "283b624d-2abb-46dc-971d-1d6352509469" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ef9f016-4a3f-4953-8d82-71f5bae831c6", "AQAAAAEAACcQAAAAEBq7p15tHpPlfidNASRaGZDIwYRSTPY6dP+4p/G/NmG27kTA6m89Ap/jGOrvqXJ4pw==", "d6d85cb4-a369-4a4f-b317-974e65eedf52" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "Calories",
                value: 100.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Menus");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de1b859d-d59f-44aa-8576-bfc001971091", "AQAAAAEAACcQAAAAEAKdHLJSn1c6Re2JbzRTEiA/FFfzt4PPEoVOqC42YsdgAKF84GArhBQxA9p8h8+c6Q==", "28f0d559-f095-42f2-b0c1-78987ff4ec4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0982160a-ead6-48ce-a1d8-ada5be29fbe3", "AQAAAAEAACcQAAAAEITVqTWLLz86E8+bwpZqfmC2xMrGf1Z/Dz+HpU5TMUUMBEeeb5zBKsa6uSOXQBZLug==", "f2e7a143-8990-413b-8568-ac4d8af30e72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ec39ad9-6512-465a-953f-5d68ab18694a", "AQAAAAEAACcQAAAAEMklDwy1ExDFVLhuycgguslN0INUlOu/45A7Ei50UnKQnQNARV+ak4HK+AV+7BQ63A==", "fde7e840-b989-4601-a333-3a89301dd1d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a907be19-e24a-4836-ae13-b6c26fa57675", "AQAAAAEAACcQAAAAEFLc4xzAMdIcsCdPP7mbD/hwx49cNSLBc4aQpIOYEdDA0NmhnKDljj0JkZj92BWNrg==", "e4349fbd-8d5b-48a2-bbcc-3a68b2ae03bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68ae11a4-4f4d-4d31-8d43-10c12a8bbf03", "AQAAAAEAACcQAAAAEFoEiHmJFHgZgzHq/xhFfZF85gxVQHLusLvOyTmxKADPN507Na0OPpfditHukruLUw==", "c7ae60b5-0acb-4c80-8b85-a17c4a05e51b" });
        }
    }
}
