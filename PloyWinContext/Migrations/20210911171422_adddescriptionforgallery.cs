﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class adddescriptionforgallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TblGallery",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TblGallery");
        }
    }
}
