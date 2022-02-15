using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class updatetableofproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "TblProducts",
                newName: "PricePerOne");

            migrationBuilder.AddColumn<string>(
                name: "MeasruingUnit",
                table: "TblProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerMeter",
                table: "TblProducts",
                type: "decimal(16,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasruingUnit",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "PricePerMeter",
                table: "TblProducts");

            migrationBuilder.RenameColumn(
                name: "PricePerOne",
                table: "TblProducts",
                newName: "Price");
        }
    }
}
