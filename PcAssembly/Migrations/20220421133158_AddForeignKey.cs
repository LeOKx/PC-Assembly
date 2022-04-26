using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Companies_CompanyName",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Components",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Components_CompanyName",
                table: "Components",
                newName: "IX_Components_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Companies_CompanyId",
                table: "Components",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Companies_CompanyId",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Components",
                newName: "CompanyName");

            migrationBuilder.RenameIndex(
                name: "IX_Components_CompanyId",
                table: "Components",
                newName: "IX_Components_CompanyName");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Companies_CompanyName",
                table: "Components",
                column: "CompanyName",
                principalTable: "Companies",
                principalColumn: "CompanyName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
