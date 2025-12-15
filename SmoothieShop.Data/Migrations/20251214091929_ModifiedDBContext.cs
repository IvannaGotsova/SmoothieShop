using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class ModifiedDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "352cf439-ebd4-41fc-8e0a-1308accf4870", "AQAAAAEAACcQAAAAEEJ3BOx2b+l7VZYGX/f99ORg6SN4rnouOdADd5cMVPFyGUXOB58A9jzJcphohfusUw==", "1a91f870-2aa4-4c65-9057-94a01c7e20f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9a323e7-760e-4150-ba46-b8122dc6550b", "AQAAAAEAACcQAAAAEOoG7SaF1WXDaXtMEXO62lvS0g+crWdESzMLDFLj6l0rNWEMZzUgGGV+RXQ6bmkPvw==", "37107480-aac9-4b4d-9185-c69db1191b53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edbef1f2-dfd9-4173-9ff4-cc2238a8b6f9", "AQAAAAEAACcQAAAAEGAaA5+Fl3ygbxSSm8ch9ldRHl8m5DNrFL7pxTzdgBzGwZ8tz8/TDlESrMyGntm3kg==", "3b5e7aad-54d5-4f91-a711-731ed44d7697" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3902b2cd-952f-4921-9bc4-4c562843c884", "AQAAAAEAACcQAAAAEONDi8tt6bX8/0ZAhQbdibCs5MWuQOmrb4itzwYBKRySMJgbRNqDzlW/898UmQGm3Q==", "81249276-29ea-4a2f-83df-c4dfe635a971" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d05daf49-0ed8-4cb4-9129-3db8497a0aa4", "AQAAAAEAACcQAAAAEA5fGZWNkXriVaas147TUbQi738bk1ifAsmv3k1kmF13av2wYHlm+dlqpKJ0QIW1iA==", "e24d50d7-6875-4666-88c9-21c6675a0d07" });
        }
    }
}
