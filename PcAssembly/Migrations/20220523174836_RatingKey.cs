using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class RatingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RatedByUserAssemblies",
                table: "RatedByUserAssemblies");

            migrationBuilder.DropIndex(
                name: "IX_RatedByUserAssemblies_UserId",
                table: "RatedByUserAssemblies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e65b021f-390a-4b3d-a9d6-350496044b30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9130dc5-a5ab-4a5c-bfc8-238051f7774e");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatedByUserAssemblies",
                table: "RatedByUserAssemblies",
                columns: new[] { "UserId", "AssemblyId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01a43e9c-36d0-4dcb-ae74-8204c4368dff", "4a293180-2c3a-42ad-adfd-75371f22d62b", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "574d292a-92e4-47af-b8cb-87acfe6a8c25", "43b65a82-0fdc-49a9-9c90-93475125037b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_RatedByUserAssemblies_AssemblyId",
                table: "RatedByUserAssemblies",
                column: "AssemblyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RatedByUserAssemblies",
                table: "RatedByUserAssemblies");

            migrationBuilder.DropIndex(
                name: "IX_RatedByUserAssemblies_AssemblyId",
                table: "RatedByUserAssemblies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01a43e9c-36d0-4dcb-ae74-8204c4368dff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "574d292a-92e4-47af-b8cb-87acfe6a8c25");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatedByUserAssemblies",
                table: "RatedByUserAssemblies",
                column: "AssemblyId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e65b021f-390a-4b3d-a9d6-350496044b30", "a4a77aef-2478-49c5-b74d-7c24bfd74e29", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9130dc5-a5ab-4a5c-bfc8-238051f7774e", "62de2414-31ea-4ac6-94e9-da893a756bb9", "Viewer", "VIEWER" });

            migrationBuilder.CreateIndex(
                name: "IX_RatedByUserAssemblies_UserId",
                table: "RatedByUserAssemblies",
                column: "UserId");
        }
    }
}
