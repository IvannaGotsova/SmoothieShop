using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class CorrectedMappedClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d55cf1b-c6e7-4fc1-acdb-6948d2769202", "AQAAAAEAACcQAAAAEMtDBic/PHOwvb6Lj2dkDEzavPZwKP0QlJ9iyFgJK+aogoYMSRR4TMbfXnfCIt39fg==", "bd5fcae3-a267-4f4c-b004-b6c48ae65cad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76bf7221-3b57-4c58-b319-e0848045bb82", "AQAAAAEAACcQAAAAEDlyi1DcWG3ZTsf/N5tbMPjIyMvWtuqvbJkz7UG7AOTzLd3FkTapLsUYAo0e6oih2Q==", "802902b4-6392-4875-99c3-19fb62d95fc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "659360ec-5a2d-4ee0-98a4-9d0f18a16aa5", "AQAAAAEAACcQAAAAELPNzAASldJ10YGcnlV4VKEzyaMFvJmdh8gMeHLlpaR1Y2uHpQdXGZaaTmZAQ9RGLQ==", "07b98f6f-7ce8-4e5c-b76c-5d14cf9c1f95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43a1ec16-0442-4444-b148-3b45fb9cf38f", "AQAAAAEAACcQAAAAELiGo5Mnh3yzMa15Z+4X5unc2h1inFrdz6aAwh+APr3/VuQIls1j0F9+S7rLU1TzKA==", "e143f899-f727-4b37-b1ef-87ef03287a01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eee6bdb-568a-47f4-bcbf-f91a595d4f8d", "AQAAAAEAACcQAAAAEFU1o6+xkzfjXLoR8LolqNXFyypBZhmFv84nxWYfbjHzwckA3vl+TLKj+qaGveMjaQ==", "145dcaa1-5065-444d-b1d7-bfb5e9779d07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
