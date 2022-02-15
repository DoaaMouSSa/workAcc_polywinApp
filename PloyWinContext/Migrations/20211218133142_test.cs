using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tblItemTypeId",
                table: "TblProductInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tblStoreTypeId",
                table: "TblProductInventory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblProductInventory_tblItemTypeId",
                table: "TblProductInventory",
                column: "tblItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProductInventory_tblStoreTypeId",
                table: "TblProductInventory",
                column: "tblStoreTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductInventory_TblItemType_tblItemTypeId",
                table: "TblProductInventory",
                column: "tblItemTypeId",
                principalTable: "TblItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductInventory_TblStoreData_tblStoreTypeId",
                table: "TblProductInventory",
                column: "tblStoreTypeId",
                principalTable: "TblStoreData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProductInventory_TblItemType_tblItemTypeId",
                table: "TblProductInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProductInventory_TblStoreData_tblStoreTypeId",
                table: "TblProductInventory");

            migrationBuilder.DropIndex(
                name: "IX_TblProductInventory_tblItemTypeId",
                table: "TblProductInventory");

            migrationBuilder.DropIndex(
                name: "IX_TblProductInventory_tblStoreTypeId",
                table: "TblProductInventory");

            migrationBuilder.DropColumn(
                name: "tblItemTypeId",
                table: "TblProductInventory");

            migrationBuilder.DropColumn(
                name: "tblStoreTypeId",
                table: "TblProductInventory");
        }
    }
}
