using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class InitCOmponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "GraphicCards");

            migrationBuilder.AlterColumn<string>(
                name: "SgRamType",
                table: "GraphicCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SgRamSize",
                table: "GraphicCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Socket",
                table: "CPUs",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Generation",
                table: "CPUs",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Family",
                table: "CPUs",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Components",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Components",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoAbout",
                table: "Components",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assemblies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CoolersCount",
                table: "Assemblies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MotherboardId",
                table: "Assemblies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PowerSupplyId",
                table: "Assemblies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RamId",
                table: "Assemblies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Chipset = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    RamType = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    RamSlots = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_Components_Id",
                        column: x => x.Id,
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplyes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplyes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerSupplyes_Components_Id",
                        column: x => x.Id,
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RamType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RamSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rams_Components_Id",
                        column: x => x.Id,
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assemblies_MotherboardId",
                table: "Assemblies",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Assemblies_PowerSupplyId",
                table: "Assemblies",
                column: "PowerSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Assemblies_RamId",
                table: "Assemblies",
                column: "RamId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Motherboards_MotherboardId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_PowerSupplyes_PowerSupplyId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Rams_RamId",
                table: "Assemblies");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "PowerSupplyes");

            migrationBuilder.DropTable(
                name: "Rams");

            migrationBuilder.DropIndex(
                name: "IX_Assemblies_MotherboardId",
                table: "Assemblies");

            migrationBuilder.DropIndex(
                name: "IX_Assemblies_PowerSupplyId",
                table: "Assemblies");

            migrationBuilder.DropIndex(
                name: "IX_Assemblies_RamId",
                table: "Assemblies");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "InfoAbout",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "CoolersCount",
                table: "Assemblies");

            migrationBuilder.DropColumn(
                name: "MotherboardId",
                table: "Assemblies");

            migrationBuilder.DropColumn(
                name: "PowerSupplyId",
                table: "Assemblies");

            migrationBuilder.DropColumn(
                name: "RamId",
                table: "Assemblies");

            migrationBuilder.AlterColumn<int>(
                name: "SgRamType",
                table: "GraphicCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SgRamSize",
                table: "GraphicCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "GraphicCards",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Socket",
                table: "CPUs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<int>(
                name: "Generation",
                table: "CPUs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Family",
                table: "CPUs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Company",
                table: "Components",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assemblies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
