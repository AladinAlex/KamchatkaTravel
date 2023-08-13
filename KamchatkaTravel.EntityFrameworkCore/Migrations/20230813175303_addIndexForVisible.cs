using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addIndexForVisible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_View_Visible",
                schema: "Travel",
                table: "View",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Visible",
                schema: "Travel",
                table: "Tour",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Visible",
                schema: "Travel",
                table: "Review",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Visible",
                schema: "Travel",
                table: "Question",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_Include_Visible",
                schema: "Travel",
                table: "Include",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Visible",
                schema: "Travel",
                table: "Image",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_Day_Visible",
                schema: "Travel",
                table: "Day",
                column: "Visible");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequest_Visible",
                schema: "Travel",
                table: "ClientRequest",
                column: "Visible");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_View_Visible",
                schema: "Travel",
                table: "View");

            migrationBuilder.DropIndex(
                name: "IX_Tour_Visible",
                schema: "Travel",
                table: "Tour");

            migrationBuilder.DropIndex(
                name: "IX_Review_Visible",
                schema: "Travel",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Question_Visible",
                schema: "Travel",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Include_Visible",
                schema: "Travel",
                table: "Include");

            migrationBuilder.DropIndex(
                name: "IX_Image_Visible",
                schema: "Travel",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Day_Visible",
                schema: "Travel",
                table: "Day");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequest_Visible",
                schema: "Travel",
                table: "ClientRequest");
        }
    }
}
