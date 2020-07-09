using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingEventsDemo.Migrations
{
    public partial class Walkthrough20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "EventCategories",
                newName: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategoryId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "EventCategories");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                column: "Id");
        }
    }
}
