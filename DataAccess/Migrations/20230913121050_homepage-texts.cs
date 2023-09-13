using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class homepagetexts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama1",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama2",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama3",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hizmetlerimiz",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsOrtaklarimiz",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SayisalVeri1",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SayisalVeri2",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SayisalVeriYazisi",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Aciklama2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Aciklama3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Hizmetlerimiz",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "IsOrtaklarimiz",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SayisalVeri1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SayisalVeri2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SayisalVeriYazisi",
                table: "HomePages");
        }
    }
}
