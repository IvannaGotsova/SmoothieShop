using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class addedpropertyMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Menus",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47cd566a-d60e-48a5-862b-6d23ed93cd28", "AQAAAAEAACcQAAAAEI5XDBmBVWcG5btxcrbh0cQa27ddrWv84ZThg6HeAwJZVsvnS3j3fnPhtRapsdOndw==", "b55ff333-1bbb-44ea-be5b-30541c0ba443" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06b97e26-d7d4-44b0-8fdd-c2e493a4af4c", "AQAAAAEAACcQAAAAEHK36rUt8iQMQjQtpDlRVdiWq6X4j5ztx9vbXpEbjpVNRNENny+HGiniAIqtK5fybQ==", "af48a16e-a5cc-4d3d-af70-bfa6c65485d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a046cd0e-1d49-40a9-b2c7-f0e5eaafa468", "AQAAAAEAACcQAAAAECKfFfXIO+lXONgT2n58nw/pq4r1VLHczEOm2pNFHn0ufu+EtLfnl4UCQVADcXJ5pg==", "e104c76d-f25a-4642-b8e3-37a84d4065cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9183b00a-b574-40df-8e8b-ea0562bc8ec5", "AQAAAAEAACcQAAAAED6DzeZ0rwZ6Q1+1Ll0UfNhfmj7+2Oudb9zGLOjqEJswhoJE9daPoe/vyPz5h80wGA==", "075b4969-2740-4534-aba6-ef3b896b3f2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf48536f-c567-49e3-bfb2-ff44f8bf1c29", "AQAAAAEAACcQAAAAEJfgRHeoNqFf8R5y5L0GqmrpK/da5JyM2PlYAZyl06ZitwtyUJyFEB16WlquT2CDcA==", "9b4e1f19-fd9d-4bb5-8f4b-7dc40095a80c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Menus");

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
    }
}
