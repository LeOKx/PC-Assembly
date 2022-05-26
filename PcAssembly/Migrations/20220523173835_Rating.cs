using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "717147d6-5428-4dfa-bbeb-f40ce36c81b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a54bdd8a-b905-483e-94cb-1d047456f104");

            migrationBuilder.CreateTable(
                name: "RatedByUserAssemblies",
                columns: table => new
                {
                    AssemblyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatedByUserAssemblies", x => x.AssemblyId);
                    table.ForeignKey(
                        name: "FK_RatedByUserAssemblies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RatedByUserAssemblies_Assemblies_AssemblyId",
                        column: x => x.AssemblyId,
                        principalTable: "Assemblies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatedByUserAssemblies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e65b021f-390a-4b3d-a9d6-350496044b30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9130dc5-a5ab-4a5c-bfc8-238051f7774e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "717147d6-5428-4dfa-bbeb-f40ce36c81b2", "3b5274d3-7813-4aca-a911-bcee8c27ba5e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a54bdd8a-b905-483e-94cb-1d047456f104", "e62770d2-1c76-42e2-9997-d9c8afb74a28", "Viewer", "VIEWER" });
        }
    }
}
