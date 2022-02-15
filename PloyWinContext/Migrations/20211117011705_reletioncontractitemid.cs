using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class reletioncontractitemid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartWarrantyDate",
                table: "TblWarrantyContracts",
                newName: "StartSectorsWarrantyDate");

            migrationBuilder.RenameColumn(
                name: "EndWarrantyDate",
                table: "TblWarrantyContracts",
                newName: "StartAccessoresWarrantyDate");

            migrationBuilder.RenameColumn(
                name: "ContractId",
                table: "TblGallaryUser",
                newName: "ContractItemId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndAccessoresWarrantyDate",
                table: "TblWarrantyContracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndSectorsWarrantyDate",
                table: "TblWarrantyContracts",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAccessoresWarrantyDate",
                table: "TblWarrantyContracts");

            migrationBuilder.DropColumn(
                name: "EndSectorsWarrantyDate",
                table: "TblWarrantyContracts");

            migrationBuilder.RenameColumn(
                name: "StartSectorsWarrantyDate",
                table: "TblWarrantyContracts",
                newName: "StartWarrantyDate");

            migrationBuilder.RenameColumn(
                name: "StartAccessoresWarrantyDate",
                table: "TblWarrantyContracts",
                newName: "EndWarrantyDate");

            migrationBuilder.RenameColumn(
                name: "ContractItemId",
                table: "TblGallaryUser",
                newName: "ContractId");
        }
    }
}
