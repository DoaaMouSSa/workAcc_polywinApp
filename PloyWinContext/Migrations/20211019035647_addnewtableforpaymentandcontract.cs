using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addnewtableforpaymentandcontract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblContractCostCalc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostCalcId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContractCostCalc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblContractCostCalc_TblContractClient_ContractId",
                        column: x => x.ContractId,
                        principalTable: "TblContractClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblContractCostCalc_TblCostCalculation_CostCalcId",
                        column: x => x.CostCalcId,
                        principalTable: "TblCostCalculation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblInstallment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallMentPayment = table.Column<double>(type: "float", nullable: true),
                    DateInstallMentPayment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatePayedInstallMentPayment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPayed = table.Column<bool>(type: "bit", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInstallment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblWarrantyContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    StartWarrantyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndWarrantyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CostCalcId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblWarrantyContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblWarrantyContracts_TblContractClient_ContractId",
                        column: x => x.ContractId,
                        principalTable: "TblContractClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblWarrantyContracts_TblCostCalculation_CostCalcId",
                        column: x => x.CostCalcId,
                        principalTable: "TblCostCalculation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblContractCostCalc_ContractId",
                table: "TblContractCostCalc",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TblContractCostCalc_CostCalcId",
                table: "TblContractCostCalc",
                column: "CostCalcId");

            migrationBuilder.CreateIndex(
                name: "IX_TblWarrantyContracts_ContractId",
                table: "TblWarrantyContracts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TblWarrantyContracts_CostCalcId",
                table: "TblWarrantyContracts",
                column: "CostCalcId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblContractCostCalc");

            migrationBuilder.DropTable(
                name: "TblInstallment");

            migrationBuilder.DropTable(
                name: "TblWarrantyContracts");
        }
    }
}
