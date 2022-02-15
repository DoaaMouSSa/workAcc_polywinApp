using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addnewtableofinvoicesanddetailsandstore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblInvoices_AspNetUsers_UserId1",
                table: "TblInvoices");

            migrationBuilder.DropIndex(
                name: "IX_TblInvoices_UserId1",
                table: "TblInvoices");

            migrationBuilder.DropColumn(
                name: "ColorBeige",
                table: "TblInvoicesDetails");

            migrationBuilder.DropColumn(
                name: "ColorWhite",
                table: "TblInvoicesDetails");

            migrationBuilder.DropColumn(
                name: "ColorWooden",
                table: "TblInvoicesDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TblInvoices");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TblInvoices");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerOne",
                table: "TblProducts",
                type: "decimal(16,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerMeter",
                table: "TblProducts",
                type: "decimal(16,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Descount",
                table: "TblInvoicesDetails",
                type: "decimal(16,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerOne",
                table: "TblInvoicesDetails",
                type: "decimal(16,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceWithDescount",
                table: "TblInvoicesDetails",
                type: "decimal(16,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromUserId",
                table: "TblInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToUserId",
                table: "TblInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "TblInvoices",
                type: "decimal(16,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPayed",
                table: "TblInvoices",
                type: "decimal(16,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descount",
                table: "TblInvoicesDetails");

            migrationBuilder.DropColumn(
                name: "PricePerOne",
                table: "TblInvoicesDetails");

            migrationBuilder.DropColumn(
                name: "PriceWithDescount",
                table: "TblInvoicesDetails");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "TblInvoices");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "TblInvoices");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "TblInvoices");

            migrationBuilder.DropColumn(
                name: "TotalPayed",
                table: "TblInvoices");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerOne",
                table: "TblProducts",
                type: "decimal(16,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerMeter",
                table: "TblProducts",
                type: "decimal(16,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorBeige",
                table: "TblInvoicesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorWhite",
                table: "TblInvoicesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorWooden",
                table: "TblInvoicesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TblInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TblInvoices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblInvoices_UserId1",
                table: "TblInvoices",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TblInvoices_AspNetUsers_UserId1",
                table: "TblInvoices",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
