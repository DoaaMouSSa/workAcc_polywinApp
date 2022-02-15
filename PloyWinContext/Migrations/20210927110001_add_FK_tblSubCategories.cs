using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class add_FK_tblSubCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSubCategories_TblParentCategories_TblParentCategoryId",
                table: "TblSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_TblSubCategories_TblParentCategoryId",
                table: "TblSubCategories");

            migrationBuilder.DropColumn(
                name: "TblParentCategoryId",
                table: "TblSubCategories");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "TblSubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblSubCategories_ParentCategoryId",
                table: "TblSubCategories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubCategories_TblParentCategories_ParentCategoryId",
                table: "TblSubCategories",
                column: "ParentCategoryId",
                principalTable: "TblParentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSubCategories_TblParentCategories_ParentCategoryId",
                table: "TblSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_TblSubCategories_ParentCategoryId",
                table: "TblSubCategories");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "TblSubCategories");

            migrationBuilder.AddColumn<int>(
                name: "TblParentCategoryId",
                table: "TblSubCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblSubCategories_TblParentCategoryId",
                table: "TblSubCategories",
                column: "TblParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubCategories_TblParentCategories_TblParentCategoryId",
                table: "TblSubCategories",
                column: "TblParentCategoryId",
                principalTable: "TblParentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
