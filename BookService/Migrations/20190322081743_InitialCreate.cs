using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    BookName = table.Column<string>(maxLength: 80, nullable: false),
                    AuthorName = table.Column<string>(maxLength: 80, nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    DatePublished = table.Column<DateTime>(nullable: false),
                    Publication = table.Column<string>(maxLength: 80, nullable: false),
                    Publisher = table.Column<string>(maxLength: 80, nullable: false),
                    About = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
