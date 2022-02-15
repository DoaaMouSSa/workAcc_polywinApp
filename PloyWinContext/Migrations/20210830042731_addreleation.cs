using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addreleation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientTypeId",
                table: "TblClient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblClient_ClientTypeId",
                table: "TblClient",
                column: "ClientTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblClient_TblClientType_ClientTypeId",
                table: "TblClient",
                column: "ClientTypeId",
                principalTable: "TblClientType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblClient_TblClientType_ClientTypeId",
                table: "TblClient");

            migrationBuilder.DropIndex(
                name: "IX_TblClient_ClientTypeId",
                table: "TblClient");

            migrationBuilder.DropColumn(
                name: "ClientTypeId",
                table: "TblClient");
        }
    }
}
