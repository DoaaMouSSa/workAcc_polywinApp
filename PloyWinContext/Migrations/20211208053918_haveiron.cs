using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class haveiron : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "haveIron",
                table: "TblParentProductCategory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "haveIron",
                table: "TblInvoicesDetails",
                type: "bit",
                nullable: true);
             
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
             
             
            migrationBuilder.DropColumn(
                name: "haveIron",
                table: "TblParentProductCategory");

            migrationBuilder.DropColumn(
                name: "haveIron",
                table: "TblInvoicesDetails");
        }
    }
}
