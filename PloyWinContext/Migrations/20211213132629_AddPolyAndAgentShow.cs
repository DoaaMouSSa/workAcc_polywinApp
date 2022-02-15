using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class AddPolyAndAgentShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "agent_show",
                table: "TblSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "poly_show",
                table: "TblSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "agent_show",
                table: "TblStoreData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "poly_show",
                table: "TblStoreData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "agent_show",
                table: "TblSupplier");

            migrationBuilder.DropColumn(
                name: "poly_show",
                table: "TblSupplier");

            migrationBuilder.DropColumn(
                name: "agent_show",
                table: "TblStoreData");

            migrationBuilder.DropColumn(
                name: "poly_show",
                table: "TblStoreData");
        }
    }
}
