using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrackerApp.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_BlacklistedFoods_BlacklistedFoodId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FavoriteFoods_FavoriteFoodId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_BlacklistedFoodId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_FavoriteFoodId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteFoods",
                table: "FavoriteFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlacklistedFoods",
                table: "BlacklistedFoods");

            migrationBuilder.DropColumn(
                name: "BlacklistedFoodId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FavoriteFoodId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoodMeals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FavoriteFoods");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BlacklistedFoods");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FavoriteFoods",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BlacklistedFoods",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteFoods",
                table: "FavoriteFoods",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlacklistedFoods",
                table: "BlacklistedFoods",
                column: "UserId");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteFoods",
                table: "FavoriteFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlacklistedFoods",
                table: "BlacklistedFoods");

            migrationBuilder.DropColumn(
                name: "BlacklistedFoodUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FavoriteFoodUserId",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlacklistedFoodId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteFoodId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FoodMeals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FavoriteFoods",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FavoriteFoods",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BlacklistedFoods",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BlacklistedFoods",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteFoods",
                table: "FavoriteFoods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlacklistedFoods",
                table: "BlacklistedFoods",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_BlacklistedFoodId",
                table: "Foods",
                column: "BlacklistedFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FavoriteFoodId",
                table: "Foods",
                column: "FavoriteFoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_BlacklistedFoods_BlacklistedFoodId",
                table: "Foods",
                column: "BlacklistedFoodId",
                principalTable: "BlacklistedFoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FavoriteFoods_FavoriteFoodId",
                table: "Foods",
                column: "FavoriteFoodId",
                principalTable: "FavoriteFoods",
                principalColumn: "Id");
        }
    }
}
