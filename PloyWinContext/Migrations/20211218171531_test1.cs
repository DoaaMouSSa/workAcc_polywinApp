using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblProductInventory");

            migrationBuilder.CreateTable(
                name: "TblPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TblProductName = table.Column<int>(type: "int", nullable: true),
                    TblItemType = table.Column<int>(type: "int", nullable: true),
                    TblStoreData = table.Column<int>(type: "int", nullable: true),
                    unit_purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    totalPrice_purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPurchase_TblItemType_TblItemType",
                        column: x => x.TblItemType,
                        principalTable: "TblItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPurchase_TblProductName_TblProductName",
                        column: x => x.TblProductName,
                        principalTable: "TblProductName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPurchase_TblStoreData_TblStoreData",
                        column: x => x.TblStoreData,
                        principalTable: "TblStoreData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_TblItemType",
                table: "TblPurchase",
                column: "TblItemType");

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_TblProductName",
                table: "TblPurchase",
                column: "TblProductName");

            migrationBuilder.CreateIndex(
                name: "IX_TblPurchase_TblStoreData",
                table: "TblPurchase",
                column: "TblStoreData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPurchase");

            migrationBuilder.CreateTable(
                name: "TblProductInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inv_id = table.Column<int>(type: "int", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: false),
                    tblItemTypeId = table.Column<int>(type: "int", nullable: true),
                    tblStoreTypeId = table.Column<int>(type: "int", nullable: true),
                    totalPrice_purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    unit_purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProductInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProductInventory_TblItemType_tblItemTypeId",
                        column: x => x.tblItemTypeId,
                        principalTable: "TblItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblProductInventory_TblStoreData_tblStoreTypeId",
                        column: x => x.tblStoreTypeId,
                        principalTable: "TblStoreData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblProductInventory_tblItemTypeId",
                table: "TblProductInventory",
                column: "tblItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProductInventory_tblStoreTypeId",
                table: "TblProductInventory",
                column: "tblStoreTypeId");
        }
    }
}
