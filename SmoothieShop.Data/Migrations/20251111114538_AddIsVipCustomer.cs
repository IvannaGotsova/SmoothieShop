using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class AddIsVipCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVip",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVip",
                table: "Customers");

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
    }
}
