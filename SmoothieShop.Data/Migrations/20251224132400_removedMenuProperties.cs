using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothieShop.Data.Migrations
{
    public partial class removedMenuProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_ProductUsers_ProductUserId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ProductUserId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ProductUserId",
                table: "Menus");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin@admin.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3658be5-516f-4967-9ce7-94808611d1f5", "AQAAAAEAACcQAAAAEDgOEEEIDiPwpVennGpHbe/lzdDGFgxn1isxgso/Lt0rNfJWNRvXYPnxrxCpuHdefw==", "70a8d23f-3f6d-440b-a00a-5947da6e19a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customerUser@customer.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6a725fc-f9f0-4188-8666-85d3f535223c", "AQAAAAEAACcQAAAAEKy6CH71tcZjxyzasxHZOmCci7IcFmi2CFagyLaZHxkNqHV/UtqowWQCu79Sy+4m6A==", "be2dde67-0bca-4165-933c-32a1ebb516b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest1@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c530c1f-df82-4115-ab12-055189d090ef", "AQAAAAEAACcQAAAAEPF5bOdL9lA5eQmel29GWMIp04j02HXIolPU7Bss7Qfot+MKMU68nzmZclFTkFgpzQ==", "dc20fc79-6cfb-465b-85dc-e1e47e3ebb6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "guest2@guest.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "594b0629-80e0-47c6-8483-351f2b20eadb", "AQAAAAEAACcQAAAAEOKL2vUciIBs0ZXtNm0rrHjmkksXt2Fd0qWyXlcipxfBP4Iz66jSd+DKrjUjMv4pSw==", "23b19df8-d2ef-4d2d-ab3e-2f38dd7d0312" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "productUser@product.com",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f143f0a-45e8-4d4b-9790-a5ae9bbaeb21", "AQAAAAEAACcQAAAAEJcHknSAJlggWbM+ZpfkMbQGxHCP0o7kFVfI4ajz3eZLN5xd/SVn0aca5CrpE1TVpg==", "db6884d9-8e5b-410e-87cd-85d140c6235e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductUserId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "ProductUserId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ProductUserId",
                table: "Menus",
                column: "ProductUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_ProductUsers_ProductUserId",
                table: "Menus",
                column: "ProductUserId",
                principalTable: "ProductUsers",
                principalColumn: "ProductUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
