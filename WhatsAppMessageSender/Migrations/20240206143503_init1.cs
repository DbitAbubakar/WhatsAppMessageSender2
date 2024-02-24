using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WhatsAppMessageSender.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compagains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CampaignStatus = table.Column<int>(nullable: false),
                    No_Of_Participants = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compagains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompagainDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    C_Id = table.Column<int>(nullable: false),
                    Number = table.Column<long>(nullable: false),
                    isSend = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompagainDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompagainDetail_Compagains_C_Id",
                        column: x => x.C_Id,
                        principalTable: "Compagains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompagainDetail_C_Id",
                table: "CompagainDetail",
                column: "C_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompagainDetail");

            migrationBuilder.DropTable(
                name: "Compagains");
        }
    }
}
