using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookStatus = table.Column<bool>(type: "bit", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterStatus = table.Column<bool>(type: "bit", nullable: false),
                    GoogleP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePStatus = table.Column<bool>(type: "bit", nullable: false),
                    Pinterest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinterestStatus = table.Column<bool>(type: "bit", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramStatus = table.Column<bool>(type: "bit", nullable: false),
                    Whatsapp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsappStatus = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
