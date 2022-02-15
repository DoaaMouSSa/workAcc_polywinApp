using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addreletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculationItems_TblSubCategories_CostCalculationId",
                table: "TblCostCalculationItems");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculationItems_TblCostCalculation_CostCalculationId",
                table: "TblCostCalculationItems",
                column: "CostCalculationId",
                principalTable: "TblCostCalculation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculationItems_TblCostCalculation_CostCalculationId",
                table: "TblCostCalculationItems");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculationItems_TblSubCategories_CostCalculationId",
                table: "TblCostCalculationItems",
                column: "CostCalculationId",
                principalTable: "TblSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
