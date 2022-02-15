using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class createtablecostCalc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCostCalculation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subCategoryId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mortal = table.Column<int>(type: "int", nullable: true),
                    expenses = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCostCalculation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCostCalculation_TblClient_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TblClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblCostCalculation_TblColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "TblColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblCostCalculation_TblSubCategories_subCategoryId",
                        column: x => x.subCategoryId,
                        principalTable: "TblSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblCostCalculationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostCalculationId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    meter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalMeterCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeOfDescount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalByDescount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCostCalculationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCostCalculationItems_TblProducts_productId",
                        column: x => x.productId,
                        principalTable: "TblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblCostCalculationItems_TblSubCategories_CostCalculationId",
                        column: x => x.CostCalculationId,
                        principalTable: "TblSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCostCalculation_ClientId",
                table: "TblCostCalculation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCostCalculation_ColorId",
                table: "TblCostCalculation",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCostCalculation_subCategoryId",
                table: "TblCostCalculation",
                column: "subCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCostCalculationItems_CostCalculationId",
                table: "TblCostCalculationItems",
                column: "CostCalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCostCalculationItems_productId",
                table: "TblCostCalculationItems",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCostCalculation");

            migrationBuilder.DropTable(
                name: "TblCostCalculationItems");
        }
    }
}
