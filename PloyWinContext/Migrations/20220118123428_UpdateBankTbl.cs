using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class UpdateBankTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TbltreasuryBank");

            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "TbltreasuryBank",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "TbltreasuryBank");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TbltreasuryBank",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
