using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class updateBanqueTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "TbltreasuryBank",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "TbltreasuryBank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "emp_name",
                table: "TbltreasuryBank",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "TbltreasuryBank");

            migrationBuilder.DropColumn(
                name: "emp_name",
                table: "TbltreasuryBank");
        }
    }
}
