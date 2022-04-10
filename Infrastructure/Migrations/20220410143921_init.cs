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
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
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
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Age = table.Column<string>(type: "varchar(200)", nullable: true),
                    Size = table.Column<string>(type: "varchar(200)", nullable: true),
                    Weight = table.Column<string>(type: "varchar(200)", nullable: true),
                    DateBirh = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Education = table.Column<string>(type: "varchar(200)", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    ProfilePath = table.Column<string>(type: "varchar(200)", nullable: true),
                    Popularity = table.Column<int>(type: "int", nullable: false),
                    SourceID = table.Column<int>(type: "int", nullable: false)
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
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    OriginalName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Subject = table.Column<string>(type: "varchar(1500)", nullable: true),
                    Producer = table.Column<string>(type: "varchar(400)", nullable: true),
                    Director = table.Column<string>(type: "varchar(75)", nullable: true),
                    Note = table.Column<string>(type: "varchar(200)", nullable: true),
                    FilmCategoryID = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "varchar(100)", nullable: true),
                    PosterPath = table.Column<string>(type: "varchar(100)", nullable: true),
                    ReleaseDate = table.Column<int>(type: "int", nullable: false),
                    SourceID = table.Column<int>(type: "int", nullable: false)
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
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    FamousID = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "varchar(200)", nullable: true),
                    ContributionID = table.Column<int>(type: "int", nullable: false)
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
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
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
                    InsertionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    FirstEpisodeAirDate = table.Column<int>(type: "int", nullable: false),
                    LastEpisodeAirDate = table.Column<int>(type: "int", nullable: false),
                    NumberofSeasons = table.Column<int>(type: "int", nullable: false),
                    NumberofEpisodes = table.Column<int>(type: "int", nullable: false),
                    Channel = table.Column<string>(type: "varchar(200)", nullable: true),
                    Producer = table.Column<string>(type: "varchar(200)", nullable: true),
                    Siciation = table.Column<string>(type: "varchar(200)", nullable: true),
                    SourceID = table.Column<int>(type: "int", nullable: false),
                    OriginalName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Country = table.Column<string>(type: "varchar(200)", nullable: true),
                    Language = table.Column<string>(type: "varchar(200)", nullable: true),
                    PosterPath = table.Column<string>(type: "varchar(200)", nullable: true),
                    Description = table.Column<string>(type: "varchar(1200)", nullable: true)
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
