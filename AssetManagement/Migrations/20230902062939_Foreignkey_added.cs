using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    public partial class Foreignkey_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RoomToAmenityMaps_AmenityId",
                table: "RoomToAmenityMaps",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomToAmenityMaps_Amenitys_AmenityId",
                table: "RoomToAmenityMaps",
                column: "AmenityId",
                principalTable: "Amenitys",
                principalColumn: "AmenityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomToAmenityMaps_Amenitys_AmenityId",
                table: "RoomToAmenityMaps");

            migrationBuilder.DropIndex(
                name: "IX_RoomToAmenityMaps_AmenityId",
                table: "RoomToAmenityMaps");
        }
    }
}
