using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class RiderEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EmExpiredate",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmIssuedate",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LabourCard",
                table: "Riders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LbExpiredate",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LbIssuedate",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RriderId",
                table: "Riders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmExpiredate",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "EmIssuedate",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "LabourCard",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "LbExpiredate",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "LbIssuedate",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "RriderId",
                table: "Riders");
        }
    }
}
