using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class updateStoreDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblStores_TblProductName_ProductNameId",
                table: "TblStores");

            migrationBuilder.DropIndex(
                name: "IX_TblStores_ProductNameId",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "ProductNameId",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "StoreData_Id",
                table: "TblStores");

            migrationBuilder.CreateIndex(
                name: "IX_TblStores_CategoryId",
                table: "TblStores",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblStores_ProductIdName",
                table: "TblStores",
                column: "ProductIdName");

            migrationBuilder.AddForeignKey(
                name: "FK_TblStores_TblCategory_CategoryId",
                table: "TblStores",
                column: "CategoryId",
                principalTable: "TblCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblStores_TblProductName_ProductIdName",
                table: "TblStores",
                column: "ProductIdName",
                principalTable: "TblProductName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblStores_TblCategory_CategoryId",
                table: "TblStores");

            migrationBuilder.DropForeignKey(
                name: "FK_TblStores_TblProductName_ProductIdName",
                table: "TblStores");

            migrationBuilder.DropIndex(
                name: "IX_TblStores_CategoryId",
                table: "TblStores");

            migrationBuilder.DropIndex(
                name: "IX_TblStores_ProductIdName",
                table: "TblStores");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "TblStores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductNameId",
                table: "TblStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreData_Id",
                table: "TblStores",
                type: "nvarchar(max)",
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
    }
}
