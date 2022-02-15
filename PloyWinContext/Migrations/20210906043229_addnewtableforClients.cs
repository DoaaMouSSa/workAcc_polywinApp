using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class addnewtableforClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblContractClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoicesNumber = table.Column<int>(type: "int", nullable: true),
                    FromUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicesDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRecived = table.Column<bool>(type: "bit", nullable: true),
                    Describtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalInvoices = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    DescountInvoices = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    TotalWithInvoices = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContractClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblGallaryUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGallaryUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblPayedContractClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moneyPerMonth = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    IsPayed = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VisicalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRealPayed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPayedContractClient", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblContractClient");

            migrationBuilder.DropTable(
                name: "TblGallaryUser");

            migrationBuilder.DropTable(
                name: "TblPayedContractClient");
        }
    }
}
