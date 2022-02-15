using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class changw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblContractCostCalc_TblContractClient_ContractId",
                table: "TblContractCostCalc");

            migrationBuilder.DropForeignKey(
                name: "FK_TblWarrantyContracts_TblContractClient_ContractId",
                table: "TblWarrantyContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblWarrantyContracts_TblCostCalculation_CostCalcId",
                table: "TblWarrantyContracts");

            migrationBuilder.AlterColumn<int>(
                name: "CostCalcId",
                table: "TblWarrantyContracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "TblWarrantyContracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "mortal",
                table: "TblCostCalculation",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "TblContractCostCalc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TblContractCostCalc_TblContractClient_ContractId",
                table: "TblContractCostCalc",
                column: "ContractId",
                principalTable: "TblContractClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblWarrantyContracts_TblContractClient_ContractId",
                table: "TblWarrantyContracts",
                column: "ContractId",
                principalTable: "TblContractClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblWarrantyContracts_TblCostCalculation_CostCalcId",
                table: "TblWarrantyContracts",
                column: "CostCalcId",
                principalTable: "TblCostCalculation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblContractCostCalc_TblContractClient_ContractId",
                table: "TblContractCostCalc");

            migrationBuilder.DropForeignKey(
                name: "FK_TblWarrantyContracts_TblContractClient_ContractId",
                table: "TblWarrantyContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblWarrantyContracts_TblCostCalculation_CostCalcId",
                table: "TblWarrantyContracts");

            migrationBuilder.AlterColumn<int>(
                name: "CostCalcId",
                table: "TblWarrantyContracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "TblWarrantyContracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "mortal",
                table: "TblCostCalculation",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "TblContractCostCalc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblContractCostCalc_TblContractClient_ContractId",
                table: "TblContractCostCalc",
                column: "ContractId",
                principalTable: "TblContractClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblWarrantyContracts_TblContractClient_ContractId",
                table: "TblWarrantyContracts",
                column: "ContractId",
                principalTable: "TblContractClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblWarrantyContracts_TblCostCalculation_CostCalcId",
                table: "TblWarrantyContracts",
                column: "CostCalcId",
                principalTable: "TblCostCalculation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
