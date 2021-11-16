using Microsoft.EntityFrameworkCore.Migrations;

namespace TailorApp_API.Migrations
{
    public partial class rolebase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prince",
                table: "tblProduct",
                newName: "price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "tblProduct",
                newName: "prince");
        }
    }
}
