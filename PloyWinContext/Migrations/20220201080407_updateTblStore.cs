using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class updateTblStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeasruingUnit",
                table: "TblStores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerMeter",
                table: "TblStores",
                type: "decimal(16,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerOne",
                table: "TblStores",
                type: "decimal(16,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreData_Id",
                table: "TblStores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasruingUnit",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "PricePerMeter",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "PricePerOne",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "StoreData_Id",
                table: "TblStores");
        }
    }
}
