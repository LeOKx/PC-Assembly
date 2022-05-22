using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class MaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32608acf-bc43-4696-8a07-27296404a3e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfb54a59-95ed-4ea3-9a25-a61bb52a815b");

            migrationBuilder.AlterColumn<string>(
                name: "InfoAbout",
                table: "Components",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19d3aae9-acf6-4e29-824b-4c5828838f46", "12a0662b-7059-43df-84c4-2b31e8d35b94", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c9129fa-ef0d-4164-b550-7d93e63c73fc", "a85c254e-09c5-42fe-a1c4-dbf0a2e80194", "Viewer", "VIEWER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19d3aae9-acf6-4e29-824b-4c5828838f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c9129fa-ef0d-4164-b550-7d93e63c73fc");

            migrationBuilder.AlterColumn<string>(
                name: "InfoAbout",
                table: "Components",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32608acf-bc43-4696-8a07-27296404a3e5", "2e33cdf6-8b37-4e3f-8371-530459b1d029", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfb54a59-95ed-4ea3-9a25-a61bb52a815b", "e529b50c-52d6-4fd4-88f7-37c642462add", "Viewer", "VIEWER" });
        }
    }
}
