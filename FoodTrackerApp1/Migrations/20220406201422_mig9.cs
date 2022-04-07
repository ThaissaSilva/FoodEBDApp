using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrackerApp.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "FavoriteFoods",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BlacklistedFoods",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteFoods_UserId1",
                table: "FavoriteFoods",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BlacklistedFoods_UserId1",
                table: "BlacklistedFoods",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlacklistedFoods_AspNetUsers_UserId1",
                table: "BlacklistedFoods",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteFoods_AspNetUsers_UserId1",
                table: "FavoriteFoods",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlacklistedFoods_AspNetUsers_UserId1",
                table: "BlacklistedFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteFoods_AspNetUsers_UserId1",
                table: "FavoriteFoods");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteFoods_UserId1",
                table: "FavoriteFoods");

            migrationBuilder.DropIndex(
                name: "IX_BlacklistedFoods_UserId1",
                table: "BlacklistedFoods");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "FavoriteFoods");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BlacklistedFoods");
        }
    }
}
