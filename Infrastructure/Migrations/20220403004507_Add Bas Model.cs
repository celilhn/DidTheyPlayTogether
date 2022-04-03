using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddBasModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Series",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Series",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Series",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "PlayedSeries",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "PlayedSeries",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "PlayedSeries",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "PlayedFilms",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "PlayedFilms",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "PlayedFilms",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Films",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Films",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Films",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Famouses",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Famouses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Famouses",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Contributions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Contributions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Contributions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "PlayedSeries");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PlayedSeries");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "PlayedSeries");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "PlayedFilms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PlayedFilms");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "PlayedFilms");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Famouses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Famouses");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Famouses");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Contributions");
        }
    }
}
