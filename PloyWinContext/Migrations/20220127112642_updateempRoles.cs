using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class updateempRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TblEmplyees",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Roles",
                newName: "Role_Name");

            migrationBuilder.AddColumn<string>(
                name: "emp_name",
                table: "TblEmplyees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emp_name",
                table: "TblEmplyees");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "TblEmplyees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Role_Name",
                table: "Roles",
                newName: "Name");
        }
    }
}
