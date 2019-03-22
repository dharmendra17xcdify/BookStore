using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Migrations
{
    public partial class Inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    BookName = table.Column<string>(maxLength: 80, nullable: false),
                    AutherId = table.Column<Guid>(nullable: false),
                    AutherName = table.Column<string>(maxLength: 80, nullable: false),
                    BookQuantityAvail = table.Column<int>(nullable: false),
                    BookQuantitySold = table.Column<int>(nullable: false),
                    BookQuantityOnOrder = table.Column<int>(nullable: false),
                    BookQuantityTotal = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
