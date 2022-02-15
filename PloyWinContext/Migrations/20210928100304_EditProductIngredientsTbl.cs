using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class EditProductIngredientsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProductIngredients_TblProducts_TblProductId",
                table: "TblProductIngredients");

            migrationBuilder.DropIndex(
                name: "IX_TblProductIngredients_TblProductId",
                table: "TblProductIngredients");

            migrationBuilder.DropColumn(
                name: "TblProductId",
                table: "TblProductIngredients");

            migrationBuilder.CreateIndex(
                name: "IX_TblProductIngredients_ProductId",
                table: "TblProductIngredients",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductIngredients_TblProducts_ProductId",
                table: "TblProductIngredients",
                column: "ProductId",
                principalTable: "TblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProductIngredients_TblProducts_ProductId",
                table: "TblProductIngredients");

            migrationBuilder.DropIndex(
                name: "IX_TblProductIngredients_ProductId",
                table: "TblProductIngredients");

            migrationBuilder.AddColumn<int>(
                name: "TblProductId",
                table: "TblProductIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblProductIngredients_TblProductId",
                table: "TblProductIngredients",
                column: "TblProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductIngredients_TblProducts_TblProductId",
                table: "TblProductIngredients",
                column: "TblProductId",
                principalTable: "TblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
