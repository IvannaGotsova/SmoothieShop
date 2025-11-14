using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class UpdateApplicationUsersCustomersCustomerUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerUsers_CustomerUserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6abc4ef1-9cb3-4b20-8615-129010513440", "AQAAAAEAACcQAAAAEApafsyC4N3We+neoajQ5BE1q2UQrUUbub0YzptuAvxM5GLzf3EsqCvfJFTxltQPLg==", "eb50ef73-9543-46ed-b6d1-f838ef9ceed0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb3a4395-1aec-424c-8f79-fc39558ff298", "AQAAAAEAACcQAAAAEF4ZNkGnICC5/iQZiy5z4lkwo2EFN4KOTKdMDAldHzXaS9UEtf8lZRNTYAMzvisRlw==", "150bce9e-6dda-47b0-8365-3a046fe20d44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98b67720-2f7e-42d5-9f78-172752a5837b", "AQAAAAEAACcQAAAAEFlYyTaJLdfVi3G1wZM/NScIB28ZnOkkpKUGy7wD2Zeq8x4RjdzUm5FjgbY0YVBY9Q==", "d5002300-5f93-4727-be94-ba6c47b438a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4b9c6a4-4d76-4a1f-8b0b-d91368fa4ff3", "AQAAAAEAACcQAAAAEDO9lbf1Oj7jH29zjVdjUqCNooZTfrlMV+0hp8R7ai+wMQ29Bqr+cZjTwZgTgZ9gAA==", "5d730c38-d890-4b37-afe1-8ce09e8d9ccc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a3de89f-7ab5-4bd5-8b29-90ab67c548ef", "AQAAAAEAACcQAAAAEPzqAJGgZ+vg0vlfc9Phd2O4OCSg/zLlDcp+HDhisdD5boiiizoYw3S5wfSgNfBsQA==", "e4954ce3-9c14-4436-b8b0-06d9e1bd405b" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "guest1@guest.com");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "guest2@guest.com");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerUserId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26ab16a6-a799-4ac2-88bc-ab238a76cb32", "AQAAAAEAACcQAAAAEIb5e96QODESNyc7yI+/Gps2sUqE4Qk/d+lhZkVW80E1v2z82mhKbw2lDjVb334PjQ==", "852d4120-d030-4a6d-a005-998a6d9d8f26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48091cd2-3df8-4b00-9d58-8d513c3ce5f3", "AQAAAAEAACcQAAAAEPiRBhkEQvQxCLJz3/edw4JX2M6ljR1SsGACFrnfE/xn3ymmLpZhpJHZhImUqLwNVQ==", "2aa0992e-ea1b-4478-bad8-89537a98935a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46d536df-8cc9-44b8-98b7-99352c75b543", "AQAAAAEAACcQAAAAEBLpshtCUCaIZvqsvYJoJ00bQ2F5lZdZWetLYzFjy4+ivpnfHnQPpGeTEEGk6Gz/fw==", "0ac82739-75e3-4458-9842-2ceabf8661d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "113a4dbc-ee36-4548-a810-f0bcd8693a58", "AQAAAAEAACcQAAAAEG9PkSV95sumgsAL885/0Ofca/jGbUmVcbjD/uNCEQNmZ98RKA5dH4JCWmg7EVWl1w==", "285a3e70-0d7e-4477-b55e-5be63bf28eaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d8b64a9-a4b5-4955-a02e-f9dd7c971843", "AQAAAAEAACcQAAAAEEkDRhvFV77g8TZQArQ2Pp/hRJpiWhBlOrBzLG+Mpl7OFS7wWqX89Ao7n+zkxTsV2A==", "0aded71d-9112-4a9c-be17-4ac387776a0a" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CustomerUserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CustomerUserId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerUserId",
                table: "Customers",
                column: "CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerUsers_CustomerUserId",
                table: "Customers",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "CustomerUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
