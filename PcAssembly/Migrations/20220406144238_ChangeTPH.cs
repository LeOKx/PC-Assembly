using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcAssembly.Migrations
{
    public partial class ChangeTPH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_CPUs_CpuId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_GraphicCards_GraphicCardId",
                table: "Assemblies");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "GraphicCards");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Components",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cores",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Family",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Frequency",
                table: "Components",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Generation",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SgRamSize",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SgRamType",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Socket",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Threads",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_Components_CpuId",
                table: "Assemblies",
                column: "CpuId",
                principalTable: "Components",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_Components_GraphicCardId",
                table: "Assemblies",
                column: "GraphicCardId",
                principalTable: "Components",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Components_CpuId",
                table: "Assemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Components_GraphicCardId",
                table: "Assemblies");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Cores",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Generation",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "SgRamSize",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "SgRamType",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Socket",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Threads",
                table: "Components");

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Family = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<float>(type: "real", nullable: false),
                    Generation = table.Column<int>(type: "int", nullable: false),
                    Socket = table.Column<int>(type: "int", nullable: false),
                    Threads = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUs_Components_Id",
                        column: x => x.Id,
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GraphicCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SgRamSize = table.Column<int>(type: "int", nullable: false),
                    SgRamType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraphicCards_Components_Id",
                        column: x => x.Id,
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_CPUs_CpuId",
                table: "Assemblies",
                column: "CpuId",
                principalTable: "CPUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_GraphicCards_GraphicCardId",
                table: "Assemblies",
                column: "GraphicCardId",
                principalTable: "GraphicCards",
                principalColumn: "Id");
        }
    }
}
