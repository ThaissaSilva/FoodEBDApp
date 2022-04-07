using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrackerApp.Migrations
{
    public partial class mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlacklistedFoodFood");

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "BlacklistedFoods",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlacklistedFoods_Foods_FoodId",
                table: "BlacklistedFoods");

            migrationBuilder.DropIndex(
                name: "IX_BlacklistedFoods_FoodId",
                table: "BlacklistedFoods");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "BlacklistedFoods");

            migrationBuilder.CreateTable(
                name: "BlacklistedFoodFood",
                columns: table => new
                {
                    BlacklistedFoodsUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlacklistedFoodFood", x => new { x.BlacklistedFoodsUserId, x.FoodsId });
                    table.ForeignKey(
                        name: "FK_BlacklistedFoodFood_BlacklistedFoods_BlacklistedFoodsUserId",
                        column: x => x.BlacklistedFoodsUserId,
                        principalTable: "BlacklistedFoods",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlacklistedFoodFood_Foods_FoodsId",
                        column: x => x.FoodsId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlacklistedFoodFood_FoodsId",
                table: "BlacklistedFoodFood",
                column: "FoodsId");
        }
    }
}
