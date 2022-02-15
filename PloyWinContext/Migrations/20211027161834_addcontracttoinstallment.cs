using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addcontracttoinstallment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "TblInstallment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblInstallment_ContractId",
                table: "TblInstallment",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblInstallment_TblContractClient_ContractId",
                table: "TblInstallment",
                column: "ContractId",
                principalTable: "TblContractClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblInstallment_TblContractClient_ContractId",
                table: "TblInstallment");

            migrationBuilder.DropIndex(
                name: "IX_TblInstallment_ContractId",
                table: "TblInstallment");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "TblInstallment");
        }
    }
}
