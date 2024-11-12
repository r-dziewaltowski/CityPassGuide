using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityPassGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CityPassRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractionCityCard");

            migrationBuilder.DropTable(
                name: "CityCards");

            migrationBuilder.CreateTable(
                name: "CityPasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValidityPeriod_StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ValidityPeriod_EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DurationInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    CoversTransport = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityPasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityPasses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttractionCityPass",
                columns: table => new
                {
                    AttractionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CityPassesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionCityPass", x => new { x.AttractionsId, x.CityPassesId });
                    table.ForeignKey(
                        name: "FK_AttractionCityPass_Attractions_AttractionsId",
                        column: x => x.AttractionsId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttractionCityPass_CityPasses_CityPassesId",
                        column: x => x.CityPassesId,
                        principalTable: "CityPasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CityPasses",
                columns: new[] { "Id", "CityId", "CoversTransport", "DurationInDays", "Name", "ValidityPeriod_EndDate", "ValidityPeriod_StartDate" },
                values: new object[,]
                {
                    { 1, 1, false, 5, "London Card", new DateOnly(9999, 12, 31), new DateOnly(2024, 1, 1) },
                    { 2, 2, true, 3, "Paris Card", new DateOnly(9999, 12, 31), new DateOnly(2024, 1, 1) },
                    { 3, 3, true, 2, "Krakow Card", new DateOnly(2024, 12, 31), new DateOnly(2024, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "AttractionCityPass",
                columns: new[] { "AttractionsId", "CityPassesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttractionCityPass_CityPassesId",
                table: "AttractionCityPass",
                column: "CityPassesId");

            migrationBuilder.CreateIndex(
                name: "IX_CityPasses_CityId_Name",
                table: "CityPasses",
                columns: new[] { "CityId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractionCityPass");

            migrationBuilder.DropTable(
                name: "CityPasses");

            migrationBuilder.CreateTable(
                name: "CityCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoversTransport = table.Column<bool>(type: "INTEGER", nullable: false),
                    DurationInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ValidityPeriod_EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ValidityPeriod_StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityCards_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttractionCityCard",
                columns: table => new
                {
                    AttractionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CityCardsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionCityCard", x => new { x.AttractionsId, x.CityCardsId });
                    table.ForeignKey(
                        name: "FK_AttractionCityCard_Attractions_AttractionsId",
                        column: x => x.AttractionsId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttractionCityCard_CityCards_CityCardsId",
                        column: x => x.CityCardsId,
                        principalTable: "CityCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CityCards",
                columns: new[] { "Id", "CityId", "CoversTransport", "DurationInDays", "Name", "ValidityPeriod_EndDate", "ValidityPeriod_StartDate" },
                values: new object[,]
                {
                    { 1, 1, false, 5, "London Card", new DateOnly(9999, 12, 31), new DateOnly(2024, 1, 1) },
                    { 2, 2, true, 3, "Paris Card", new DateOnly(9999, 12, 31), new DateOnly(2024, 1, 1) },
                    { 3, 3, true, 2, "Krakow Card", new DateOnly(2024, 12, 31), new DateOnly(2024, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "AttractionCityCard",
                columns: new[] { "AttractionsId", "CityCardsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttractionCityCard_CityCardsId",
                table: "AttractionCityCard",
                column: "CityCardsId");

            migrationBuilder.CreateIndex(
                name: "IX_CityCards_CityId_Name",
                table: "CityCards",
                columns: new[] { "CityId", "Name" },
                unique: true);
        }
    }
}
