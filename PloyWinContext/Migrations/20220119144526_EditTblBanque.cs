using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class EditTblBanque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "In",
                table: "TbltreasuryBank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Left",
                table: "TbltreasuryBank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrderType",
                table: "TbltreasuryBank",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Out",
                table: "TbltreasuryBank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "TbltreasuryBank",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "In",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "Left",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "Out",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "TbltreasuryBank");
        }
    }
}
