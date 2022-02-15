using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblSupplier_TblSupplierId",
                table: "TblPurchase");

            migrationBuilder.DropIndex(
                name: "IX_TblPurchase_TblSupplierId",
                table: "TblPurchase");

            migrationBuilder.DropColumn(
                name: "TblSupplierId",
                table: "TblPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_SupplierId",
                table: "TblPurchase",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblSupplier_SupplierId",
                table: "TblPurchase",
                column: "SupplierId",
                principalTable: "TblSupplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblSupplier_SupplierId",
                table: "TblPurchase");

            migrationBuilder.DropIndex(
                name: "IX_TblPurchase_SupplierId",
                table: "TblPurchase");

            migrationBuilder.AddColumn<int>(
                name: "TblSupplierId",
                table: "TblPurchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_TblSupplierId",
                table: "TblPurchase",
                column: "TblSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblSupplier_TblSupplierId",
                table: "TblPurchase",
                column: "TblSupplierId",
                principalTable: "TblSupplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
