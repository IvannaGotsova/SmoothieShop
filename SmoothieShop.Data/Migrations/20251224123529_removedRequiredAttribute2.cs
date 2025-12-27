using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class removedRequiredAttribute2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ede10b3f-c3d9-4482-b83d-94582e807f37", "AQAAAAEAACcQAAAAEBhFMcHPn7i3UWqspRnGxIVKBx+Q8WdhNp9q8ovuzeWRhs8RXXUigfMyLEVKp/30Tg==", "171ea69a-ecf0-41c7-8dcb-021f6f480b1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "011ba9ab-33d9-43d4-a3cb-0ebf2833ce5c", "AQAAAAEAACcQAAAAEKDXSc78E8zM3MUZlwfno2R0CF5t16pedctFKRtU6o9FvEscqEFKmhca8SBC86c/qQ==", "32683b33-6621-4c40-84dd-b3789a284228" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a9093ee-ca6c-4235-a6ba-cfc6cd3d67c0", "AQAAAAEAACcQAAAAEG8zzOUr9IwhJn/wxvWuzoiTDekkXcUM4LXfZh5in4nYhzZrVaOesVYfsQLDIj3tmA==", "835d7bfa-6674-476f-be51-6265ec49e709" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40a46f35-3a17-4d70-b8a4-2c7a67f3d638", "AQAAAAEAACcQAAAAEGL1unMquFn7/BiiBEErOCRw0T3SfyKaT/B00gDTema+/6T+q1njqW9kNzOhBlDwSQ==", "40a36748-bf7f-4f48-8c6d-f1da8cdd46d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6908f853-31b3-415b-bac6-5a2cad18905b", "AQAAAAEAACcQAAAAELPZzE+6lyAgQZHnC3ZDvPLZ3FXnkKQ1eGrQ2gMYPro6wDpcjZdx/TcsxflenoX6MA==", "cc4830b7-512f-4b21-bdf6-4cf8c50a86d8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
