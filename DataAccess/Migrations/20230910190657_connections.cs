using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class connections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Messages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LinkID",
                table: "Footers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuggestionID",
                table: "Footers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AboutFooter",
                columns: table => new
                {
                    AboutID = table.Column<int>(type: "int", nullable: false),
                    FooterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutFooter", x => new { x.AboutID, x.FooterID });
                    table.ForeignKey(
                        name: "FK_AboutFooter_Abouts_AboutID",
                        column: x => x.AboutID,
                        principalTable: "Abouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutFooter_Footers_FooterID",
                        column: x => x.FooterID,
                        principalTable: "Footers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactFooter",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    FooterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactFooter", x => new { x.ContactID, x.FooterID });
                    table.ForeignKey(
                        name: "FK_ContactFooter_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactFooter_Footers_FooterID",
                        column: x => x.FooterID,
                        principalTable: "Footers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FooterHomePage",
                columns: table => new
                {
                    FooterID = table.Column<int>(type: "int", nullable: false),
                    HomePageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterHomePage", x => new { x.FooterID, x.HomePageID });
                    table.ForeignKey(
                        name: "FK_FooterHomePage_Footers_FooterID",
                        column: x => x.FooterID,
                        principalTable: "Footers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FooterHomePage_HomePages_HomePageID",
                        column: x => x.HomePageID,
                        principalTable: "HomePages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FooterUrunler",
                columns: table => new
                {
                    FooterID = table.Column<int>(type: "int", nullable: false),
                    UrunlerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterUrunler", x => new { x.FooterID, x.UrunlerID });
                    table.ForeignKey(
                        name: "FK_FooterUrunler_Footers_FooterID",
                        column: x => x.FooterID,
                        principalTable: "Footers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FooterUrunler_Urunlers_UrunlerID",
                        column: x => x.UrunlerID,
                        principalTable: "Urunlers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ContactID",
                table: "Messages",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Footers_LinkID",
                table: "Footers",
                column: "LinkID");

            migrationBuilder.CreateIndex(
                name: "IX_Footers_SuggestionID",
                table: "Footers",
                column: "SuggestionID");

            migrationBuilder.CreateIndex(
                name: "IX_AboutFooter_FooterID",
                table: "AboutFooter",
                column: "FooterID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactFooter_FooterID",
                table: "ContactFooter",
                column: "FooterID");

            migrationBuilder.CreateIndex(
                name: "IX_FooterHomePage_HomePageID",
                table: "FooterHomePage",
                column: "HomePageID");

            migrationBuilder.CreateIndex(
                name: "IX_FooterUrunler_UrunlerID",
                table: "FooterUrunler",
                column: "UrunlerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Footers_Links_LinkID",
                table: "Footers",
                column: "LinkID",
                principalTable: "Links",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Footers_Suggestions_SuggestionID",
                table: "Footers",
                column: "SuggestionID",
                principalTable: "Suggestions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Contacts_ContactID",
                table: "Messages",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footers_Links_LinkID",
                table: "Footers");

            migrationBuilder.DropForeignKey(
                name: "FK_Footers_Suggestions_SuggestionID",
                table: "Footers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Contacts_ContactID",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "AboutFooter");

            migrationBuilder.DropTable(
                name: "ContactFooter");

            migrationBuilder.DropTable(
                name: "FooterHomePage");

            migrationBuilder.DropTable(
                name: "FooterUrunler");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ContactID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Footers_LinkID",
                table: "Footers");

            migrationBuilder.DropIndex(
                name: "IX_Footers_SuggestionID",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LinkID",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "SuggestionID",
                table: "Footers");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
