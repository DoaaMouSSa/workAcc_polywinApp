using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class updateStoreTbl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblStores_TblCategory_CategoryId",
                table: "TblStores");

            migrationBuilder.DropIndex(
                name: "IX_TblStores_CategoryId",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "MeasruingUnit",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "PricePerMeter",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "PricePerOne",
                table: "TblStores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TblStores",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TblStores_CategoryId",
                table: "TblStores",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblStores_TblCategory_CategoryId",
                table: "TblStores",
                column: "CategoryId",
                principalTable: "TblCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
