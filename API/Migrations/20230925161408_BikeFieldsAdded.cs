using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class BikeFieldsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BikeChasis",
                table: "Bikes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BikeColor",
                table: "Bikes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BikeName",
                table: "Bikes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BikeOwner",
                table: "Bikes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Bikes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssueCity",
                table: "Bikes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Bikes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MulkiyaNumber",
                table: "Bikes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BikeChasis",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "BikeColor",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "BikeName",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "BikeOwner",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "IssueCity",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "MulkiyaNumber",
                table: "Bikes");
        }
    }
}
