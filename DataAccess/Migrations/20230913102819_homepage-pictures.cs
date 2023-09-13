using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class homepagepictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HakkimizdaFoto1",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HakkimizdaFoto2",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HizmetlerimizFoto1",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HizmetlerimizFoto2",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HizmetlerimizFoto3",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsOrtaklarimizFoto1",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsOrtaklarimizFoto2",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsOrtaklarimizFoto3",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsOrtaklarimizFoto4",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsOrtaklarimizFoto5",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsOrtaklarimizFoto6",
                table: "HomePages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HakkimizdaFoto1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "HakkimizdaFoto2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "HizmetlerimizFoto1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "HizmetlerimizFoto2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "HizmetlerimizFoto3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "IsOrtaklarimizFoto1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "IsOrtaklarimizFoto2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "IsOrtaklarimizFoto3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "IsOrtaklarimizFoto4",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "IsOrtaklarimizFoto5",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "IsOrtaklarimizFoto6",
                table: "HomePages");
        }
    }
}
