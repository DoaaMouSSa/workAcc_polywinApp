using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class AddProductIngredientAccessoryTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblProductIngredientAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CountOfItems = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProductIngredientAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProductIngredientAccessory_TblProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblProductIngredientAccessory_TblSubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "TblSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblProductIngredientAccessory_ProductId",
                table: "TblProductIngredientAccessory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProductIngredientAccessory_SubCategoryId",
                table: "TblProductIngredientAccessory",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblProductIngredientAccessory");
        }
    }
}
