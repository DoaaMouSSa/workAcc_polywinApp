using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class tblPurchaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unit_purchase",
                table: "TblPurchase",
                newName: "priceForOnePiece");

            migrationBuilder.RenameColumn(
                name: "test",
                table: "TblPurchase",
                newName: "NumberOfPieces");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceOfAllPieces",
                table: "TblPurchase",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceOfAllPieces",
                table: "TblPurchase");

            migrationBuilder.RenameColumn(
                name: "priceForOnePiece",
                table: "TblPurchase",
                newName: "unit_purchase");

            migrationBuilder.RenameColumn(
                name: "NumberOfPieces",
                table: "TblPurchase",
                newName: "test");
        }
    }
}
