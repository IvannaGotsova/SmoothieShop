using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class addedMenuPriceSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "785c0fc0-0b73-4721-951d-cdb6da847924", "AQAAAAEAACcQAAAAEJysIuB6eyx03tMOaDEvG+vW4s/UOiFb+ZIgWkzJ1tObFXRXr9wNcG5fblVK/Cq3Ug==", "f8df4948-c30e-4a53-8256-64ba711c99c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e042aa4e-dbec-49a4-9f6b-60737c060ed3", "AQAAAAEAACcQAAAAECYiC0fi/TXYcJcQhpAnpleQIJdjiyMoU7jd3t+yGeuQNm2RjEN+z3FVnlxjC/aAVg==", "92c8025e-9756-46a1-8c9c-dfa36e08f69f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f1e2642-669c-4be3-a172-2efcdbaa135f", "AQAAAAEAACcQAAAAEFjGLl0RXt9jkshMv2pYSsmlQEXU8OWUwUk56S6Jq0uk/dVIKl9oCSfG2/hqB+F3ng==", "43b49c7f-2899-4cd6-a635-183d0f10e803" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa4dd293-66b6-431c-b7b5-fa551b83c087", "AQAAAAEAACcQAAAAEPQwigzaXg3n6Feqed7p4m7O70ydRbtg3Z5IgHrUqjm+lduB4EAPoxCJ38JZ/jn6AA==", "f09d481d-71fc-487f-83ed-533cb6450827" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9c13416-d563-4e05-8634-f485ecd1738f", "AQAAAAEAACcQAAAAEBjjsr9iozvXkdGLjz4hzLfGBJweUddFfrfu/+OSoyJDMYDL4N2U9qC6+QJAk0uJ4w==", "4ee432cd-f4bc-4a44-b491-3c00567a00a3" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "Price",
                value: 10m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "Price",
                value: 0m);
        }
    }
}
