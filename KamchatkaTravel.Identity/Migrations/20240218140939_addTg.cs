using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.Identity.Migrations
{
    /// <inheritdoc />
    public partial class addTg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonTelegram",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chat_Id = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTelegram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonTelegram_IdentityPerson_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Identity",
                        principalTable: "IdentityPerson",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTelegram_Id",
                schema: "Identity",
                table: "PersonTelegram",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonTelegram_PersonId",
                schema: "Identity",
                table: "PersonTelegram",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTelegram",
                schema: "Identity");
        }
    }
}
