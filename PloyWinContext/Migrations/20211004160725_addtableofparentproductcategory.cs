using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addtableofparentproductcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "TblProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TblParentProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatgoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblParentProductCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblProducts_ColorId",
                table: "TblProducts",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCategory_TypeOfCategory",
                table: "TblCategory",
                column: "TypeOfCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCategory_TblParentProductCategory_TypeOfCategory",
                table: "TblCategory",
                column: "TypeOfCategory",
                principalTable: "TblParentProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblColors_ColorId",
                table: "TblProducts",
                column: "ColorId",
                principalTable: "TblColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCategory_TblParentProductCategory_TypeOfCategory",
                table: "TblCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblColors_ColorId",
                table: "TblProducts");

            migrationBuilder.DropTable(
                name: "TblParentProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_TblProducts_ColorId",
                table: "TblProducts");

            migrationBuilder.DropIndex(
                name: "IX_TblCategory_TypeOfCategory",
                table: "TblCategory");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "TblProducts");
        }
    }
}
