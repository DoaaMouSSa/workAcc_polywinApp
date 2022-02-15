using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addcategorytype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryTypeId",
                table: "TblCategoryGallary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TblCategoryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategoryType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCategoryGallary_CategoryTypeId",
                table: "TblCategoryGallary",
                column: "CategoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCategoryGallary_TblCategoryType_CategoryTypeId",
                table: "TblCategoryGallary",
                column: "CategoryTypeId",
                principalTable: "TblCategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCategoryGallary_TblCategoryType_CategoryTypeId",
                table: "TblCategoryGallary");

            migrationBuilder.DropTable(
                name: "TblCategoryType");

            migrationBuilder.DropIndex(
                name: "IX_TblCategoryGallary_CategoryTypeId",
                table: "TblCategoryGallary");

            migrationBuilder.DropColumn(
                name: "CategoryTypeId",
                table: "TblCategoryGallary");
        }
    }
}
