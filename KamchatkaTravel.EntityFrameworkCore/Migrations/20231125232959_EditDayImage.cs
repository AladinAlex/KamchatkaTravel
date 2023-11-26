using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class EditDayImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Travel",
                table: "Day");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Travel",
                table: "Day",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Travel",
                table: "Day");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "Travel",
                table: "Day",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
