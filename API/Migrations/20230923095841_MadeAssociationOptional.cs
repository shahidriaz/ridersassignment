using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class MadeAssociationOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiderBikeAssociation_Bikes_BikeId",
                table: "RiderBikeAssociation");

            migrationBuilder.DropForeignKey(
                name: "FK_RiderBikeAssociation_Riders_RiderId",
                table: "RiderBikeAssociation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiderBikeAssociation",
                table: "RiderBikeAssociation");

            migrationBuilder.RenameTable(
                name: "RiderBikeAssociation",
                newName: "RiderBikeAssociations");

            migrationBuilder.RenameIndex(
                name: "IX_RiderBikeAssociation_RiderId",
                table: "RiderBikeAssociations",
                newName: "IX_RiderBikeAssociations_RiderId");

            migrationBuilder.RenameIndex(
                name: "IX_RiderBikeAssociation_BikeId",
                table: "RiderBikeAssociations",
                newName: "IX_RiderBikeAssociations_BikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiderBikeAssociations",
                table: "RiderBikeAssociations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiderBikeAssociations_Bikes_BikeId",
                table: "RiderBikeAssociations",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiderBikeAssociations_Riders_RiderId",
                table: "RiderBikeAssociations",
                column: "RiderId",
                principalTable: "Riders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiderBikeAssociations_Bikes_BikeId",
                table: "RiderBikeAssociations");

            migrationBuilder.DropForeignKey(
                name: "FK_RiderBikeAssociations_Riders_RiderId",
                table: "RiderBikeAssociations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiderBikeAssociations",
                table: "RiderBikeAssociations");

            migrationBuilder.RenameTable(
                name: "RiderBikeAssociations",
                newName: "RiderBikeAssociation");

            migrationBuilder.RenameIndex(
                name: "IX_RiderBikeAssociations_RiderId",
                table: "RiderBikeAssociation",
                newName: "IX_RiderBikeAssociation_RiderId");

            migrationBuilder.RenameIndex(
                name: "IX_RiderBikeAssociations_BikeId",
                table: "RiderBikeAssociation",
                newName: "IX_RiderBikeAssociation_BikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiderBikeAssociation",
                table: "RiderBikeAssociation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiderBikeAssociation_Bikes_BikeId",
                table: "RiderBikeAssociation",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiderBikeAssociation_Riders_RiderId",
                table: "RiderBikeAssociation",
                column: "RiderId",
                principalTable: "Riders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
