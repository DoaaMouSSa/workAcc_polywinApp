using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculation_TblClient_ClientId",
                table: "TblCostCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculation_TblColors_ColorId",
                table: "TblCostCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculation_TblSubCategories_subCategoryId",
                table: "TblCostCalculation");

            migrationBuilder.AlterColumn<int>(
                name: "subCategoryId",
                table: "TblCostCalculation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "TblCostCalculation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "TblCostCalculation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculation_TblClient_ClientId",
                table: "TblCostCalculation",
                column: "ClientId",
                principalTable: "TblClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculation_TblColors_ColorId",
                table: "TblCostCalculation",
                column: "ColorId",
                principalTable: "TblColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculation_TblSubCategories_subCategoryId",
                table: "TblCostCalculation",
                column: "subCategoryId",
                principalTable: "TblSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculation_TblClient_ClientId",
                table: "TblCostCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculation_TblColors_ColorId",
                table: "TblCostCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCostCalculation_TblSubCategories_subCategoryId",
                table: "TblCostCalculation");

            migrationBuilder.AlterColumn<int>(
                name: "subCategoryId",
                table: "TblCostCalculation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "TblCostCalculation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "TblCostCalculation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculation_TblClient_ClientId",
                table: "TblCostCalculation",
                column: "ClientId",
                principalTable: "TblClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculation_TblColors_ColorId",
                table: "TblCostCalculation",
                column: "ColorId",
                principalTable: "TblColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCostCalculation_TblSubCategories_subCategoryId",
                table: "TblCostCalculation",
                column: "subCategoryId",
                principalTable: "TblSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
