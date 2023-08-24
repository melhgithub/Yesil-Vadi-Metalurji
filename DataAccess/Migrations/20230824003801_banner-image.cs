using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class bannerimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Banner",
                table: "HomePages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Image",
                table: "HomePages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Banner",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Image",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Banner",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Image",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Banner",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Banner",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Abouts");
        }
    }
}
