using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class homepagecontactabout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl6 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl7 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl8 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl9 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl10 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl6 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl7 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl8 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl9 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl10 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl6 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl7 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl8 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl9 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl10 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "HomePages");
        }
    }
}
