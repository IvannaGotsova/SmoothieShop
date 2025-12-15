using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class addedOrderProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
