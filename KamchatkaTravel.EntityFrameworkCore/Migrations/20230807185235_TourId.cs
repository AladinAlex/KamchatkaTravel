using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class TourId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Tour_TourId",
                schema: "Travel",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Tour_TourId",
                schema: "Travel",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Include_Tour_TourId",
                schema: "Travel",
                table: "Include");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                schema: "Travel",
                table: "Include",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                schema: "Travel",
                table: "Image",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                schema: "Travel",
                table: "Day",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Tour_TourId",
                schema: "Travel",
                table: "Day",
                column: "TourId",
                principalSchema: "Travel",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Tour_TourId",
                schema: "Travel",
                table: "Image",
                column: "TourId",
                principalSchema: "Travel",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Include_Tour_TourId",
                schema: "Travel",
                table: "Include",
                column: "TourId",
                principalSchema: "Travel",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Tour_TourId",
                schema: "Travel",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Tour_TourId",
                schema: "Travel",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Include_Tour_TourId",
                schema: "Travel",
                table: "Include");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                schema: "Travel",
                table: "Include",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                schema: "Travel",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                schema: "Travel",
                table: "Day",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Tour_TourId",
                schema: "Travel",
                table: "Day",
                column: "TourId",
                principalSchema: "Travel",
                principalTable: "Tour",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Tour_TourId",
                schema: "Travel",
                table: "Image",
                column: "TourId",
                principalSchema: "Travel",
                principalTable: "Tour",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Include_Tour_TourId",
                schema: "Travel",
                table: "Include",
                column: "TourId",
                principalSchema: "Travel",
                principalTable: "Tour",
                principalColumn: "Id");
        }
    }
}
