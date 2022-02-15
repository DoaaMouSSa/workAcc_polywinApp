using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class editpurchaseTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "TblPurchase",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblSupplier_TblSupplierId",
                table: "TblPurchase");

            migrationBuilder.DropIndex(
                name: "IX_TblPurchase_TblSupplierId",
                table: "TblPurchase");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "TblPurchase");

            migrationBuilder.DropColumn(
                name: "TblSupplierId",
                table: "TblPurchase");
        }
    }
}
