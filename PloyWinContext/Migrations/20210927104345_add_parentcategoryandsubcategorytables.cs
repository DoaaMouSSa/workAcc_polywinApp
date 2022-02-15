using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class add_parentcategoryandsubcategorytables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblGallery_TblCategoryGallary_TblCategoryGallaryId",
                table: "TblGallery");

            migrationBuilder.DropIndex(
                name: "IX_TblGallery_TblCategoryGallaryId",
                table: "TblGallery");

            migrationBuilder.DropColumn(
                name: "TblCategoryGallaryId",
                table: "TblGallery");

            migrationBuilder.CreateTable(
                name: "TblParentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblParentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TblParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSubCategories_TblParentCategories_TblParentCategoryId",
                        column: x => x.TblParentCategoryId,
                        principalTable: "TblParentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblSubCategories_TblParentCategoryId",
                table: "TblSubCategories",
                column: "TblParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblSubCategories");

            migrationBuilder.DropTable(
                name: "TblParentCategories");

            migrationBuilder.AddColumn<int>(
                name: "TblCategoryGallaryId",
                table: "TblGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblGallery_TblCategoryGallaryId",
                table: "TblGallery",
                column: "TblCategoryGallaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblGallery_TblCategoryGallary_TblCategoryGallaryId",
                table: "TblGallery",
                column: "TblCategoryGallaryId",
                principalTable: "TblCategoryGallary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
