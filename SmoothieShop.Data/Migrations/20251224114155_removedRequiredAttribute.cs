using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class removedRequiredAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c87a22bd-0842-4a1f-bd9c-353bffadce23", "AQAAAAEAACcQAAAAEN0AlNE8oRM6YPzNrGideZtfXGNbyYjExj/mX2Qxf919CKEc9lPzlAgLTwXb3SGvew==", "c91dc1c7-0ae6-48b1-8dd5-f66f25b2fb63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff0ac1e4-281f-4ed1-a235-ff1e48c7a758", "AQAAAAEAACcQAAAAEHk6K5FWE8s9LGrqD7YWLmpMiuVeBoGtS0kMQAtj7fzM5hdogWhl9/05yK3Y09CoZQ==", "b871a6eb-dd6a-40af-8c3a-78ee5171482d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21f1c981-d5e4-4063-aafe-ca6e02459dbe", "AQAAAAEAACcQAAAAEAjpAqVX8NdiCT0U5s3sWnEXfx95C/4fd55RGx+dMVyyqJ2CZ3Xki+LGuVnxOig4Nw==", "cdfc8ad1-889e-481b-853d-6f58248c45c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3044e9e-52aa-4ade-a08f-0d5a92fa9269", "AQAAAAEAACcQAAAAECwrutfiC/FkCyjuFE/Oba2v7Wj4rTO1kEjUmJnZS/YLqy49CsOiXBN9mEjGyofpQw==", "acca7f11-c0a7-4334-b24d-0034ff4a69c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "319ea445-924f-4b0a-9d29-766de722c331", "AQAAAAEAACcQAAAAEPryZ/M9w2yP4oVC62CrsDuogPezEA0DMDXz8atM5rnBUkZArF1Cf3LDsEVD/o3NXg==", "4965281a-349b-4861-9dce-053fc25225e2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
