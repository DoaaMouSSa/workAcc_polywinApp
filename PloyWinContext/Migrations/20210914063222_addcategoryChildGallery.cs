using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addcategoryChildGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblGallery_TblCategoryGallary_CategoryGallaryId",
                table: "TblGallery");

            migrationBuilder.RenameColumn(
                name: "CategoryGallaryId",
                table: "TblGallery",
                newName: "CategoryChildGallaryId");

            migrationBuilder.RenameIndex(
                name: "IX_TblGallery_CategoryGallaryId",
                table: "TblGallery",
                newName: "IX_TblGallery_CategoryChildGallaryId");

            migrationBuilder.AddColumn<int>(
                name: "TblCategoryGallaryId",
                table: "TblGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblCategoryChildGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryChildName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryGallaryId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategoryChildGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCategoryChildGallery_TblCategoryGallary_CategoryGallaryId",
                        column: x => x.CategoryGallaryId,
                        principalTable: "TblCategoryGallary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblGallery_TblCategoryGallaryId",
                table: "TblGallery",
                column: "TblCategoryGallaryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCategoryChildGallery_CategoryGallaryId",
                table: "TblCategoryChildGallery",
                column: "CategoryGallaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblGallery_TblCategoryChildGallery_CategoryChildGallaryId",
                table: "TblGallery",
                column: "CategoryChildGallaryId",
                principalTable: "TblCategoryChildGallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblGallery_TblCategoryGallary_TblCategoryGallaryId",
                table: "TblGallery",
                column: "TblCategoryGallaryId",
                principalTable: "TblCategoryGallary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblGallery_TblCategoryChildGallery_CategoryChildGallaryId",
                table: "TblGallery");

            migrationBuilder.DropForeignKey(
                name: "FK_TblGallery_TblCategoryGallary_TblCategoryGallaryId",
                table: "TblGallery");

            migrationBuilder.DropTable(
                name: "TblCategoryChildGallery");

            migrationBuilder.DropIndex(
                name: "IX_TblGallery_TblCategoryGallaryId",
                table: "TblGallery");

            migrationBuilder.DropColumn(
                name: "TblCategoryGallaryId",
                table: "TblGallery");

            migrationBuilder.RenameColumn(
                name: "CategoryChildGallaryId",
                table: "TblGallery",
                newName: "CategoryGallaryId");

            migrationBuilder.RenameIndex(
                name: "IX_TblGallery_CategoryChildGallaryId",
                table: "TblGallery",
                newName: "IX_TblGallery_CategoryGallaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblGallery_TblCategoryGallary_CategoryGallaryId",
                table: "TblGallery",
                column: "CategoryGallaryId",
                principalTable: "TblCategoryGallary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
