using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addtableofc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblColors_ColorId",
                table: "TblProducts");

            migrationBuilder.DropIndex(
                name: "IX_TblProducts_ColorId",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "TblProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "TblProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblProducts_ColorId",
                table: "TblProducts",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblColors_ColorId",
                table: "TblProducts",
                column: "ColorId",
                principalTable: "TblColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
