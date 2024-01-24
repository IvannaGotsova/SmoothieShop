using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class addApplicationRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IngredientInfo",
                table: "Ingredients",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a13d75b4-720d-4d60-9005-8baff9841251", "AQAAAAEAACcQAAAAEFHCIuAoea5RyWHcN1NLkpx6fbNvR4g5GYiRlGp5UrcF5VDhZC5eynotzCbAO8fghQ==", "4a946958-befe-4bf8-a2c4-9a262b5daa13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ee0f48e-5d40-4b7e-bad2-ba2730cd4e69", "AQAAAAEAACcQAAAAEL1rU6nymXURviA7/WtedCUE29z5mDHu4CIF+coS0W9EE6zpsn0qgtqTPhA0wfKM2A==", "a7b1f19f-1b44-4019-932d-83c4f975668a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb9454da-e01e-4ae8-b034-256d28f678c9", "AQAAAAEAACcQAAAAEBAjlfXiC27Gws7jE733Nlf3Heo+0ouwrMNLqsyEzW5j2Hcn/45GT+8JGgboN9YC0w==", "f325b408-69cb-40ff-aea9-b9791233c0f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a99bef1-44d7-4024-8dc7-e78f31e2b76f", "AQAAAAEAACcQAAAAEF2680EvaqqdUS+pBAvjttbGcsudtc9SHtyH0Aid0mHupAgyYmvubNIbwDJaDahJEQ==", "93e345e6-5862-4898-8a0e-3a6e5c5b826e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "040026e9-b518-4df4-a209-99db80d7e173", "AQAAAAEAACcQAAAAEOuuag23Qa7Q+Slxi351zFAdlnbWeQpEDJevfnxFh3DbknFBUQqRTobITp8aywau1Q==", "85009476-af4c-4375-a24c-01fb5c73406b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "IngredientInfo",
                table: "Ingredients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0c1621d-e5af-4a36-a183-da319abbccb8", "AQAAAAEAACcQAAAAEMH48+D6AllfN8L9oQCwZWVCHfSqbU9/I5+o7CycsJDTFDj9FF/Z67cIj5opJ3MnhQ==", "2ddb4c08-798d-4e46-83f2-9328aaa91003" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e50d5ddf-1d33-4c7f-8105-48806751877d", "AQAAAAEAACcQAAAAEFnen7B2VhzL7KKTfKrSDyDibAjCSuKcIhlfT5tijbYk5O/ncz+6ljCJQYJX79HpDA==", "0a3656ee-846b-47c8-a97f-2233fe7b01a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0b3fbaf-01c4-4eca-8e9d-1a22d62e4a0f", "AQAAAAEAACcQAAAAEG1vleKKMHVk0zakDZ8ht/T1aHm388yikSXIC+i75LQOGXpdYNEBgUrSJYSRuTyJOQ==", "63d13704-ac4f-4d99-9f9c-d608460fb805" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "801f1274-729b-4c1f-be7b-1434ea65d03c", "AQAAAAEAACcQAAAAEAxOs3YZ8LW1h6aYeLsGZllwBzJeC808zaoc/PoF4ucAvz41xwv/URdgTiiQAzFFvQ==", "84c8866f-853d-48de-a4ed-e999de09f6a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9ca09ce-1b5f-48b6-a140-cff5fe16d2fb", "AQAAAAEAACcQAAAAEJLifgbh2C342b7DXNl+repjwAA0KlSewliA0RSL4zeKnIcCUZy06V4xjl35ULJ5YA==", "f96d3be5-998a-46ff-a719-b51926f9b37d" });
        }
    }
}
