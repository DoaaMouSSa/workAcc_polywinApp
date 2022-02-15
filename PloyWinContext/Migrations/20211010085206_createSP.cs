using Microsoft.EntityFrameworkCore.Migrations;

namespace PloyWinContext.Migrations
{
    public partial class createSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
create proc getExuationOfProduct @productId int,  @width nvarchar(30),@height nvarchar(30)
 AS
 declare @x nvarchar(100)
select @x= REPLACE(REPLACE(Equation,'H',@width),'W',@height)   from TblProductIngredients  where productId = @productId
EXECUTE sp_executesql   @x 
GO";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
