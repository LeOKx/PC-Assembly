using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class InitialRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96e01772-776b-45fc-aa51-3516629fbb59", "e832cd8e-6612-4940-b3b0-a2036e7ba794", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4e7a069-eb1d-454c-a31c-f91d34623a00", "73da7650-f1f1-4150-80d4-94c7fcf603dd", "Viewer", "VIEWER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96e01772-776b-45fc-aa51-3516629fbb59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4e7a069-eb1d-454c-a31c-f91d34623a00");
        }
    }
}
