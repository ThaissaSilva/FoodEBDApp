using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrackerApp.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_BlacklistedFoods_BlacklistedFoodUserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_BlacklistedFoodUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "BlacklistedFoodUserId",
                table: "Foods");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlacklistedFoodFood");

            migrationBuilder.AddColumn<string>(
                name: "BlacklistedFoodUserId",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_BlacklistedFoodUserId",
                table: "Foods",
                column: "BlacklistedFoodUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_BlacklistedFoods_BlacklistedFoodUserId",
                table: "Foods",
                column: "BlacklistedFoodUserId",
                principalTable: "BlacklistedFoods",
                principalColumn: "UserId");
        }
    }
}
