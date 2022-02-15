using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class releationdescountwithcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfProduct",
                table: "TblDescount",
                newName: "TypeOfCategory");

            migrationBuilder.CreateIndex(
                name: "IX_TblDescount_TypeOfCategory",
                table: "TblDescount",
                column: "TypeOfCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_TblDescount_TblParentProductCategory_TypeOfCategory",
                table: "TblDescount",
                column: "TypeOfCategory",
                principalTable: "TblParentProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblDescount_TblParentProductCategory_TypeOfCategory",
                table: "TblDescount");

            migrationBuilder.DropIndex(
                name: "IX_TblDescount_TypeOfCategory",
                table: "TblDescount");

            migrationBuilder.RenameColumn(
                name: "TypeOfCategory",
                table: "TblDescount",
                newName: "TypeOfProduct");
        }
    }
}
