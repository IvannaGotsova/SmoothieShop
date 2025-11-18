using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class ChangeApplicationUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductUsers_ApplicationUserId",
                table: "ProductUsers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_ApplicationUserId",
                table: "CustomerUsers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8f7756c-ebed-4598-9b9f-e3bbe1cf3e91", "AQAAAAEAACcQAAAAEDLOTnMcfXsbOVfcM+H4WeSu3lqudmNlIfuoanp4qSfS/SdTkfFyPRlLUtHRc2pwTg==", "802ede99-9420-4622-aa8d-46a3ca1bcf48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "531385a9-9a61-43e2-a207-e856f70c7937", "AQAAAAEAACcQAAAAEEjekMHHA0XJjWqBTdOwI56l+KaNXVIj1jBr/WF/MeFWR48usq4gLcUlT/zAY+8Cfg==", "4a9ee33e-8645-466b-906c-0d50da2e5b2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71e69454-f829-46ae-bb19-cc6b74c147c6", "AQAAAAEAACcQAAAAEKyg1mlp6W0e7tVQv6oHctIJLR9fVFMC4GCLbUPs/kol5LuK2pHkT9OhTAr94pjMzQ==", "321ff1fd-9a14-4b3f-9702-d3d591dbeaaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb4ee382-b6f2-4091-aa11-f7d991072240", "AQAAAAEAACcQAAAAEA4njRJsn1cvDNkNBwKqc0BL1//9u9ryjBmg7Eb3NaJYonW5OOvQKCTm3aVJizoYWw==", "582f5ca2-0f28-4b81-8bf9-3c8af208dd91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "813e3d91-908c-4a21-8e8d-b6561f06e3eb", "AQAAAAEAACcQAAAAEHWpn8j/ZnthnpvI8EAgEOwnpzeDdTh+McDduf1OGYoKBjtvdRG646pH2JUvs0dw7w==", "b068cabf-600c-4c4b-9f71-b7cd78bb3c8b" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductUsers_ApplicationUserId",
                table: "ProductUsers",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_ApplicationUserId",
                table: "CustomerUsers",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductUsers_ApplicationUserId",
                table: "ProductUsers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_ApplicationUserId",
                table: "CustomerUsers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductUsers_ApplicationUserId",
                table: "ProductUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_ApplicationUserId",
                table: "CustomerUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId");
        }
    }
}
