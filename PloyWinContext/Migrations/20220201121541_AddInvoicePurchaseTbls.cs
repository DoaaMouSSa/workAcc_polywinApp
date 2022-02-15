using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class AddInvoicePurchaseTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblPurchase_Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price_Invoice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPurchase_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPurchase_Invoice_TblCurrency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "TblCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPurchase_Invoice_TblSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TblSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblPurchase_Invoices_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProuctIdName = table.Column<int>(type: "int", nullable: true),
                    ProuctId = table.Column<int>(type: "int", nullable: true),
                    Invoice_id = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TPrice_Product = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPurchase_Invoices_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPurchase_Invoices_Details_TblProductName_ProuctIdName",
                        column: x => x.ProuctIdName,
                        principalTable: "TblProductName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPurchase_Invoices_Details_TblProducts_ProuctId",
                        column: x => x.ProuctId,
                        principalTable: "TblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPurchase_Invoices_Details_TblPurchase_Invoice_Invoice_id",
                        column: x => x.Invoice_id,
                        principalTable: "TblPurchase_Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_Invoice_CurrencyId",
                table: "TblPurchase_Invoice",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_Invoice_SupplierId",
                table: "TblPurchase_Invoice",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_Invoices_Details_Invoice_id",
                table: "TblPurchase_Invoices_Details",
                column: "Invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_Invoices_Details_ProuctId",
                table: "TblPurchase_Invoices_Details",
                column: "ProuctId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_Invoices_Details_ProuctIdName",
                table: "TblPurchase_Invoices_Details",
                column: "ProuctIdName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPurchase_Invoices_Details");

            migrationBuilder.DropTable(
                name: "TblPurchase_Invoice");
        }
    }
}
