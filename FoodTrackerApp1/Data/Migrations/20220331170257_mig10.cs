using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrackerApp.Data.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlacklistedFoods_Foods_FoodId",
                table: "BlacklistedFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteFoods_Foods_FoodId",
                table: "FavoriteFoods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteFoods_FoodId",
                table: "FavoriteFoods");

            migrationBuilder.DropIndex(
                name: "IX_BlacklistedFoods_FoodId",
                table: "BlacklistedFoods");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "FavoriteFoods");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "BlacklistedFoods");

            migrationBuilder.AddColumn<string>(
                name: "BlacklistedFoodUserId",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteFoodUserId",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_BlacklistedFoodUserId",
                table: "Foods",
                column: "BlacklistedFoodUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FavoriteFoodUserId",
                table: "Foods",
                column: "FavoriteFoodUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_BlacklistedFoods_BlacklistedFoodUserId",
                table: "Foods",
                column: "BlacklistedFoodUserId",
                principalTable: "BlacklistedFoods",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FavoriteFoods_FavoriteFoodUserId",
                table: "Foods",
                column: "FavoriteFoodUserId",
                principalTable: "FavoriteFoods",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_BlacklistedFoods_BlacklistedFoodUserId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FavoriteFoods_FavoriteFoodUserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_BlacklistedFoodUserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_FavoriteFoodUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "BlacklistedFoodUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FavoriteFoodUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "FavoriteFoods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "BlacklistedFoods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteFoods_FoodId",
                table: "FavoriteFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BlacklistedFoods_FoodId",
                table: "BlacklistedFoods",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlacklistedFoods_Foods_FoodId",
                table: "BlacklistedFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteFoods_Foods_FoodId",
                table: "FavoriteFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");
        }
    }
}
