using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96e01772-776b-45fc-aa51-3516629fbb59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4e7a069-eb1d-454c-a31c-f91d34623a00");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32608acf-bc43-4696-8a07-27296404a3e5", "2e33cdf6-8b37-4e3f-8371-530459b1d029", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfb54a59-95ed-4ea3-9a25-a61bb52a815b", "e529b50c-52d6-4fd4-88f7-37c642462add", "Viewer", "VIEWER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32608acf-bc43-4696-8a07-27296404a3e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfb54a59-95ed-4ea3-9a25-a61bb52a815b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96e01772-776b-45fc-aa51-3516629fbb59", "e832cd8e-6612-4940-b3b0-a2036e7ba794", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4e7a069-eb1d-454c-a31c-f91d34623a00", "73da7650-f1f1-4150-80d4-94c7fcf603dd", "Viewer", "VIEWER" });
        }
    }
}
