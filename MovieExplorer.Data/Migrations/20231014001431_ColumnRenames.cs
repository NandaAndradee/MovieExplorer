using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieExplorer.Data.Migrations
{
    public partial class ColumnRenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "movies",
                newName: "title");

            migrationBuilder.AddColumn<string>(
                name: "original_title",
                table: "movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "original_title",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "movies",
                newName: "name");
        }
    }
}
