using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class purchasetblpolywin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblItemType_TblItemType",
                table: "TblPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblProductName_TblProductName",
                table: "TblPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblStoreData_TblStoreData",
                table: "TblPurchase");

            migrationBuilder.RenameColumn(
                name: "TblStoreData",
                table: "TblPurchase",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "TblProductName",
                table: "TblPurchase",
                newName: "ProuctId");

            migrationBuilder.RenameColumn(
                name: "TblItemType",
                table: "TblPurchase",
                newName: "ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TblPurchase_TblStoreData",
                table: "TblPurchase",
                newName: "IX_TblPurchase_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_TblPurchase_TblProductName",
                table: "TblPurchase",
                newName: "IX_TblPurchase_ProuctId");

            migrationBuilder.RenameIndex(
                name: "IX_TblPurchase_TblItemType",
                table: "TblPurchase",
                newName: "IX_TblPurchase_ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblItemType_ItemTypeId",
                table: "TblPurchase",
                column: "ItemTypeId",
                principalTable: "TblItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblProductName_ProuctId",
                table: "TblPurchase",
                column: "ProuctId",
                principalTable: "TblProductName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblStoreData_StoreId",
                table: "TblPurchase",
                column: "StoreId",
                principalTable: "TblStoreData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblItemType_ItemTypeId",
                table: "TblPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblProductName_ProuctId",
                table: "TblPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPurchase_TblStoreData_StoreId",
                table: "TblPurchase");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "TblPurchase",
                newName: "TblStoreData");

            migrationBuilder.RenameColumn(
                name: "ProuctId",
                table: "TblPurchase",
                newName: "TblProductName");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "TblPurchase",
                newName: "TblItemType");

            migrationBuilder.RenameIndex(
                name: "IX_TblPurchase_StoreId",
                table: "TblPurchase",
                newName: "IX_TblPurchase_TblStoreData");

            migrationBuilder.RenameIndex(
                name: "IX_TblPurchase_ProuctId",
                table: "TblPurchase",
                newName: "IX_TblPurchase_TblProductName");

            migrationBuilder.RenameIndex(
                name: "IX_TblPurchase_ItemTypeId",
                table: "TblPurchase",
                newName: "IX_TblPurchase_TblItemType");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblItemType_TblItemType",
                table: "TblPurchase",
                column: "TblItemType",
                principalTable: "TblItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblProductName_TblProductName",
                table: "TblPurchase",
                column: "TblProductName",
                principalTable: "TblProductName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPurchase_TblStoreData_TblStoreData",
                table: "TblPurchase",
                column: "TblStoreData",
                principalTable: "TblStoreData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
