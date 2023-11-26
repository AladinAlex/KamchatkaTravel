﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class EditTourLOgoImg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LogoImageUrl",
                schema: "Travel",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "LogoImageUrl",
                schema: "Travel",
                table: "Tour",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
