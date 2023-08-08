using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addCommentToClientRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "comment",
                schema: "Travel",
                table: "ClientRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequest_TourId",
                schema: "Travel",
                table: "ClientRequest",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_Tour_TourId",
                schema: "Travel",
                table: "ClientRequest",
                column: "TourId",
                principalSchema: "Travel",
                principalTable: "Tour",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_Tour_TourId",
                schema: "Travel",
                table: "ClientRequest");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequest_TourId",
                schema: "Travel",
                table: "ClientRequest");

            migrationBuilder.DropColumn(
                name: "comment",
                schema: "Travel",
                table: "ClientRequest");
        }
    }
}
