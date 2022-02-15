using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class changereleationproductcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProductIngredientAccessory_TblProducts_ProductId",
                table: "TblProductIngredientAccessory");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProductIngredients_TblProducts_ProductId",
                table: "TblProductIngredients");

            migrationBuilder.AddColumn<int>(
                name: "TblProductsId",
                table: "TblProductIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TblProductsId",
                table: "TblProductIngredientAccessory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblProductIngredients_TblProductsId",
                table: "TblProductIngredients",
                column: "TblProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProductIngredientAccessory_TblProductsId",
                table: "TblProductIngredientAccessory",
                column: "TblProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductIngredientAccessory_TblProductName_ProductId",
                table: "TblProductIngredientAccessory",
                column: "ProductId",
                principalTable: "TblProductName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductIngredientAccessory_TblProducts_TblProductsId",
                table: "TblProductIngredientAccessory",
                column: "TblProductsId",
                principalTable: "TblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductIngredients_TblProductName_ProductId",
                table: "TblProductIngredients",
                column: "ProductId",
                principalTable: "TblProductName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductIngredients_TblProducts_TblProductsId",
                table: "TblProductIngredients",
                column: "TblProductsId",
                principalTable: "TblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProductIngredientAccessory_TblProductName_ProductId",
                table: "TblProductIngredientAccessory");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProductIngredientAccessory_TblProducts_TblProductsId",
                table: "TblProductIngredientAccessory");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProductIngredients_TblProductName_ProductId",
                table: "TblProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProductIngredients_TblProducts_TblProductsId",
                table: "TblProductIngredients");

            migrationBuilder.DropIndex(
                name: "IX_TblProductIngredients_TblProductsId",
                table: "TblProductIngredients");

            migrationBuilder.DropIndex(
                name: "IX_TblProductIngredientAccessory_TblProductsId",
                table: "TblProductIngredientAccessory");

            migrationBuilder.DropColumn(
                name: "TblProductsId",
                table: "TblProductIngredients");

            migrationBuilder.DropColumn(
                name: "TblProductsId",
                table: "TblProductIngredientAccessory");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductIngredientAccessory_TblProducts_ProductId",
                table: "TblProductIngredientAccessory",
                column: "ProductId",
                principalTable: "TblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductIngredients_TblProducts_ProductId",
                table: "TblProductIngredients",
                column: "ProductId",
                principalTable: "TblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
