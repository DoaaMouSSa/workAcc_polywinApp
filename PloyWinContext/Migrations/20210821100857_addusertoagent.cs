using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addusertoagent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "TblAgent",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TblAgent",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblAgent_UserId1",
                table: "TblAgent",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAgent_AspNetUsers_UserId1",
                table: "TblAgent",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAgent_AspNetUsers_UserId1",
                table: "TblAgent");

            migrationBuilder.DropIndex(
                name: "IX_TblAgent_UserId1",
                table: "TblAgent");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TblAgent");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TblAgent");
        }
    }
}
