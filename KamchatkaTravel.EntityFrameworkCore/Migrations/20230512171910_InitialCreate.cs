using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Travel");

            migrationBuilder.CreateTable(
                name: "ClientRequest",
                schema: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    isProcessed = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                schema: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                schema: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Tagline = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    LogoImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SeasonType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NightType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", nullable: false),
                    DescriptionImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LinkEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                schema: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day_Tour_TourId",
                        column: x => x.TourId,
                        principalSchema: "Travel",
                        principalTable: "Tour",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Img = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Ord = table.Column<int>(type: "int", nullable: true),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Tour_TourId",
                        column: x => x.TourId,
                        principalSchema: "Travel",
                        principalTable: "Tour",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Include",
                schema: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    isInclude = table.Column<bool>(type: "bit", nullable: false),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Include", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Include_Tour_TourId",
                        column: x => x.TourId,
                        principalSchema: "Travel",
                        principalTable: "Tour",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Ord = table.Column<int>(type: "int", nullable: true),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Tour_TourId",
                        column: x => x.TourId,
                        principalSchema: "Travel",
                        principalTable: "Tour",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "View",
                schema: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_View", x => x.Id);
                    table.ForeignKey(
                        name: "FK_View_Tour_TourId",
                        column: x => x.TourId,
                        principalSchema: "Travel",
                        principalTable: "Tour",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequest_Id",
                schema: "Travel",
                table: "ClientRequest",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Day_Id",
                schema: "Travel",
                table: "Day",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Day_TourId",
                schema: "Travel",
                table: "Day",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Id",
                schema: "Travel",
                table: "Image",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_TourId",
                schema: "Travel",
                table: "Image",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Include_Id",
                schema: "Travel",
                table: "Include",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Include_TourId",
                schema: "Travel",
                table: "Include",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Id",
                schema: "Travel",
                table: "Question",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_TourId",
                schema: "Travel",
                table: "Question",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Id",
                schema: "Travel",
                table: "Review",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Id",
                schema: "Travel",
                table: "Tour",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_View_Id",
                schema: "Travel",
                table: "View",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_View_TourId",
                schema: "Travel",
                table: "View",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientRequest",
                schema: "Travel");

            migrationBuilder.DropTable(
                name: "Day",
                schema: "Travel");

            migrationBuilder.DropTable(
                name: "Image",
                schema: "Travel");

            migrationBuilder.DropTable(
                name: "Include",
                schema: "Travel");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Travel");

            migrationBuilder.DropTable(
                name: "Review",
                schema: "Travel");

            migrationBuilder.DropTable(
                name: "View",
                schema: "Travel");

            migrationBuilder.DropTable(
                name: "Tour",
                schema: "Travel");
        }
    }
}
