using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class reletioncont : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblWarrantyContracts_TblCostCalculation_CostCalcId",
                table: "TblWarrantyContracts");

            migrationBuilder.RenameColumn(
                name: "CostCalcId",
                table: "TblWarrantyContracts",
                newName: "ContractCostCalcId");

            migrationBuilder.RenameIndex(
                name: "IX_TblWarrantyContracts_CostCalcId",
                table: "TblWarrantyContracts",
                newName: "IX_TblWarrantyContracts_ContractCostCalcId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblWarrantyContracts_TblContractCostCalc_ContractCostCalcId",
                table: "TblWarrantyContracts",
                column: "ContractCostCalcId",
                principalTable: "TblContractCostCalc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblWarrantyContracts_TblContractCostCalc_ContractCostCalcId",
                table: "TblWarrantyContracts");

            migrationBuilder.RenameColumn(
                name: "ContractCostCalcId",
                table: "TblWarrantyContracts",
                newName: "CostCalcId");

            migrationBuilder.RenameIndex(
                name: "IX_TblWarrantyContracts_ContractCostCalcId",
                table: "TblWarrantyContracts",
                newName: "IX_TblWarrantyContracts_CostCalcId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblWarrantyContracts_TblCostCalculation_CostCalcId",
                table: "TblWarrantyContracts",
                column: "CostCalcId",
                principalTable: "TblCostCalculation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
