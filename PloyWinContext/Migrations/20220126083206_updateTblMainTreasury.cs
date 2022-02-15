using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class updateTblMainTreasury : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "TbltreasuryBank");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "TbltreasuryBank",
                newName: "filePath");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "TbltreasuryBank",
                newName: "LogoPath");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "TbltreasuryBank",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbltreasuryBank_CurrencyId",
                table: "TbltreasuryBank",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbltreasuryBank_TblCurrency_CurrencyId",
                table: "TbltreasuryBank",
                column: "CurrencyId",
                principalTable: "TblCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbltreasuryBank_TblCurrency_CurrencyId",
                table: "TbltreasuryBank");

            migrationBuilder.DropIndex(
                name: "IX_TbltreasuryBank_CurrencyId",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "TbltreasuryBank");

            migrationBuilder.RenameColumn(
                name: "filePath",
                table: "TbltreasuryBank",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "LogoPath",
                table: "TbltreasuryBank",
                newName: "ImagePath");

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "TbltreasuryBank",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
