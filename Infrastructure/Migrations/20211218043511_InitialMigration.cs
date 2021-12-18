using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    MelFunctionChance = table.Column<double>(type: "float", nullable: false),
                    MelFunctionsOccured = table.Column<int>(type: "int", nullable: false),
                    DistanceConverInMiles = table.Column<int>(type: "int", nullable: false),
                    FinishedRace = table.Column<int>(type: "int", nullable: false),
                    RacedForHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorbikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    MelfunctionChance = table.Column<double>(type: "float", nullable: false),
                    MelfunctionsOccured = table.Column<int>(type: "int", nullable: false),
                    DistanceCoverdInMiles = table.Column<int>(type: "int", nullable: false),
                    FinishedRace = table.Column<int>(type: "int", nullable: false),
                    RacedForHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorbikes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Motorbikes");
        }
    }
}
