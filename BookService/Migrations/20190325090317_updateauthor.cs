using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Migrations
{
    public partial class updateauthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Awards",
                table: "Authors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Books",
                table: "Authors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Awards",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Books",
                table: "Authors");
        }
    }
}
