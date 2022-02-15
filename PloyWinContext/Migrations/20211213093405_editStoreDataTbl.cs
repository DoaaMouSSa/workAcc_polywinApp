using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class editStoreDataTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreAddress",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "StoreBranch",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "StoreIs_Active",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "TblStores");

            migrationBuilder.DropColumn(
                name: "StorePhone",
                table: "TblStores");

            migrationBuilder.RenameColumn(
                name: "StoreWorker",
                table: "TblStores",
                newName: "StoreData_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreData_Id",
                table: "TblStores",
                newName: "StoreWorker");

            migrationBuilder.AddColumn<string>(
                name: "StoreAddress",
                table: "TblStores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreBranch",
                table: "TblStores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StoreIs_Active",
                table: "TblStores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "TblStores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorePhone",
                table: "TblStores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
