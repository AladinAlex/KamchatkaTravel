using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addRouteName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteName",
                schema: "Travel",
                table: "Tour",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteName",
                schema: "Travel",
                table: "Tour");
        }
    }
}
