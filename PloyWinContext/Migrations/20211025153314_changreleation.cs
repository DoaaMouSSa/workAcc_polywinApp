using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class changreleation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculationItems_TblProducts_productId",
                table: "TblCostCalculationItems");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculationItems_TblProductName_productId",
                table: "TblCostCalculationItems",
                column: "productId",
                principalTable: "TblProductName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculationItems_TblProductName_productId",
                table: "TblCostCalculationItems");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculationItems_TblProducts_productId",
                table: "TblCostCalculationItems",
                column: "productId",
                principalTable: "TblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
