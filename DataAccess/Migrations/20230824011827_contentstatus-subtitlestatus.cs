using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class contentstatussubtitlestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContentStatus",
                table: "HomePages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubtitleStatus",
                table: "HomePages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ContentStatus",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubtitleStatus",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ContentStatus",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubtitleStatus",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentStatus",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SubtitleStatus",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ContentStatus",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SubtitleStatus",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContentStatus",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "SubtitleStatus",
                table: "Abouts");
        }
    }
}
