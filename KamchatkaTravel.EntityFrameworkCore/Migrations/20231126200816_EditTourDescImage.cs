using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class EditTourDescImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionImage",
                schema: "Travel",
                table: "Tour");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionImageUrl",
                schema: "Travel",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionImageUrl",
                schema: "Travel",
                table: "Tour");

            migrationBuilder.AddColumn<byte[]>(
                name: "DescriptionImage",
                schema: "Travel",
                table: "Tour",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
