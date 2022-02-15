using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class UpdatePurchaseTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblStoreData_StoreId",
                table: "TblPurchase");

            migrationBuilder.DropIndex(
                name: "IX_TblPurchase_StoreId",
                table: "TblPurchase");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "TblPurchase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "TblPurchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_StoreId",
                table: "TblPurchase",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblStoreData_StoreId",
                table: "TblPurchase",
                column: "StoreId",
                principalTable: "TblStoreData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
