using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class setnullableofcolor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblColors_ColorId",
                table: "TblProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "TblProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblColors_ColorId",
                table: "TblProducts",
                column: "ColorId",
                principalTable: "TblColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblColors_ColorId",
                table: "TblProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "TblProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
