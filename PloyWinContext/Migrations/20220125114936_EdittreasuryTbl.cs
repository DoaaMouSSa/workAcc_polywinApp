using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class EdittreasuryTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bank_Id",
                table: "TbltreasuryBank",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Payment_Id",
                table: "TbltreasuryBank",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbltreasuryBank_Bank_Id",
                table: "TbltreasuryBank",
                column: "Bank_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TbltreasuryBank_Payment_Id",
                table: "TbltreasuryBank",
                column: "Payment_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbltreasuryBank_TblBank_Bank_Id",
                table: "TbltreasuryBank",
                column: "Bank_Id",
                principalTable: "TblBank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TbltreasuryBank_TblPaymentMethods_Payment_Id",
                table: "TbltreasuryBank",
                column: "Payment_Id",
                principalTable: "TblPaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbltreasuryBank_TblBank_Bank_Id",
                table: "TbltreasuryBank");

            migrationBuilder.DropForeignKey(
                name: "FK_TbltreasuryBank_TblPaymentMethods_Payment_Id",
                table: "TbltreasuryBank");

            migrationBuilder.DropIndex(
                name: "IX_TbltreasuryBank_Bank_Id",
                table: "TbltreasuryBank");

            migrationBuilder.DropIndex(
                name: "IX_TbltreasuryBank_Payment_Id",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "Bank_Id",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "Payment_Id",
                table: "TbltreasuryBank");
        }
    }
}
