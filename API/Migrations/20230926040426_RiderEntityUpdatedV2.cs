using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class RiderEntityUpdatedV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VisaCategory",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisaSponsor",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingCity",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingStatus",
                table: "Riders",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisaCategory",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "VisaSponsor",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "WorkingCity",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "WorkingStatus",
                table: "Riders");
        }
    }
}
