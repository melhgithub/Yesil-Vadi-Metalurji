using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class titlestatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TitleStatus",
                table: "Urunlers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TitleStatus",
                table: "HomePages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TitleStatus",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TitleStatus",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleStatus",
                table: "Urunlers");

            migrationBuilder.DropColumn(
                name: "TitleStatus",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "TitleStatus",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "TitleStatus",
                table: "Abouts");
        }
    }
}
