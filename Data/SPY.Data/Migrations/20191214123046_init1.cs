using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPY.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddManagerId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsSlide",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ModifyManagerId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "SeoKeyword",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "Articles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddManagerId",
                table: "Articles",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSlide",
                table: "Articles",
                maxLength: 1,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifyManagerId",
                table: "Articles",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Articles",
                maxLength: 23,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "Articles",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeyword",
                table: "Articles",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "Articles",
                maxLength: 128,
                nullable: true);
        }
    }
}
