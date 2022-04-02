using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contributions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Famouses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Age = table.Column<string>(type: "varchar(200)", nullable: true),
                    Size = table.Column<string>(type: "varchar(200)", nullable: true),
                    Weight = table.Column<string>(type: "varchar(200)", nullable: true),
                    DateBirh = table.Column<DateTime>(type: "datetime", nullable: false),
                    Education = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Famouses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Subject = table.Column<string>(type: "varchar(200)", nullable: true),
                    Producer = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayedFilms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    FamousID = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "varchar(200)", nullable: true),
                    ContributionID = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayedFilms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayedSeries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    FamousID = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "varchar(200)", nullable: true),
                    Year = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayedSeries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    FirstEpisodeAirDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastEpisodeAirDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumberofSeasons = table.Column<int>(type: "int", nullable: false),
                    NumberofEpisodes = table.Column<int>(type: "int", nullable: false),
                    Channel = table.Column<string>(type: "varchar(200)", nullable: true),
                    Producer = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributions");

            migrationBuilder.DropTable(
                name: "Famouses");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "PlayedFilms");

            migrationBuilder.DropTable(
                name: "PlayedSeries");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
