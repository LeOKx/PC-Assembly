using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class ProfileAssembly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_AspNetUsers_UserId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Motherboards_MotherboardId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_PowerSupplyes_PowerSupplyId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Rams_RamId",
                table: "Assemblies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19d3aae9-acf6-4e29-824b-4c5828838f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c9129fa-ef0d-4164-b550-7d93e63c73fc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "717147d6-5428-4dfa-bbeb-f40ce36c81b2", "3b5274d3-7813-4aca-a911-bcee8c27ba5e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a54bdd8a-b905-483e-94cb-1d047456f104", "e62770d2-1c76-42e2-9997-d9c8afb74a28", "Viewer", "VIEWER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_AspNetUsers_UserId",
                table: "Assemblies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_Motherboards_MotherboardId",
                table: "Assemblies",
                column: "MotherboardId",
                principalTable: "Motherboards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_PowerSupplyes_PowerSupplyId",
                table: "Assemblies",
                column: "PowerSupplyId",
                principalTable: "PowerSupplyes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_Rams_RamId",
                table: "Assemblies",
                column: "RamId",
                principalTable: "Rams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_AspNetUsers_UserId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Motherboards_MotherboardId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_PowerSupplyes_PowerSupplyId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Rams_RamId",
                table: "Assemblies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "717147d6-5428-4dfa-bbeb-f40ce36c81b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a54bdd8a-b905-483e-94cb-1d047456f104");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19d3aae9-acf6-4e29-824b-4c5828838f46", "12a0662b-7059-43df-84c4-2b31e8d35b94", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c9129fa-ef0d-4164-b550-7d93e63c73fc", "a85c254e-09c5-42fe-a1c4-dbf0a2e80194", "Viewer", "VIEWER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_AspNetUsers_UserId",
                table: "Assemblies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_Motherboards_MotherboardId",
                table: "Assemblies",
                column: "MotherboardId",
                principalTable: "Motherboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_PowerSupplyes_PowerSupplyId",
                table: "Assemblies",
                column: "PowerSupplyId",
                principalTable: "PowerSupplyes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_Rams_RamId",
                table: "Assemblies",
                column: "RamId",
                principalTable: "Rams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
