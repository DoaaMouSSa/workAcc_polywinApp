using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addemailandcontractonpayedclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractClientId",
                table: "TblPayedContractClient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TblClient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TblAgent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPayedContractClient_ContractClientId",
                table: "TblPayedContractClient",
                column: "ContractClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPayedContractClient_TblContractClient_ContractClientId",
                table: "TblPayedContractClient",
                column: "ContractClientId",
                principalTable: "TblContractClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPayedContractClient_TblContractClient_ContractClientId",
                table: "TblPayedContractClient");

            migrationBuilder.DropIndex(
                name: "IX_TblPayedContractClient_ContractClientId",
                table: "TblPayedContractClient");

            migrationBuilder.DropColumn(
                name: "ContractClientId",
                table: "TblPayedContractClient");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TblClient");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TblAgent");
        }
    }
}
