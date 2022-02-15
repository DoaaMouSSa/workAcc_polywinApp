using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addtableprod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "TblProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TblProductName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProductName", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblProducts_ProductId",
                table: "TblProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblProductName_ProductId",
                table: "TblProducts",
                column: "ProductId",
                principalTable: "TblProductName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblProductName_ProductId",
                table: "TblProducts");

            migrationBuilder.DropTable(
                name: "TblProductName");

            migrationBuilder.DropIndex(
                name: "IX_TblProducts_ProductId",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "TblProducts");
        }
    }
}
