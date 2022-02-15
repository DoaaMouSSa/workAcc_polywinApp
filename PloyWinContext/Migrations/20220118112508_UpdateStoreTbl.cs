using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class UpdateStoreTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TblStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "TblStores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductIdName",
                table: "TblStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductNameId",
                table: "TblStores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblStores_ProductNameId",
                table: "TblStores",
                column: "ProductNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblStores_TblProductName_ProductNameId",
                table: "TblStores",
                column: "ProductNameId",
                principalTable: "TblProductName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblStores_TblProductName_ProductNameId",
                table: "TblStores");

            migrationBuilder.DropIndex(
                name: "IX_TblStores_ProductNameId",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "ProductIdName",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "ProductNameId",
                table: "TblStores");
        }
    }
}
