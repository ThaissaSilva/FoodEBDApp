using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrackerApp.Data.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MealUserId",
                table: "Meals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealUserId",
                table: "Meals",
                column: "MealUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Meals_MealUserId",
                table: "Meals",
                column: "MealUserId",
                principalTable: "Meals",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Meals_MealUserId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MealUserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealUserId",
                table: "Meals");
        }
    }
}
