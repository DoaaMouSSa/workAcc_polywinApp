using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class EditTblPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "TblPurchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_CurrencyId",
                table: "TblPurchase",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblCurrency_CurrencyId",
                table: "TblPurchase",
                column: "CurrencyId",
                principalTable: "TblCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblCurrency_CurrencyId",
                table: "TblPurchase");

            migrationBuilder.DropIndex(
                name: "IX_TblPurchase_CurrencyId",
                table: "TblPurchase");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "TblPurchase");
        }
    }
}
