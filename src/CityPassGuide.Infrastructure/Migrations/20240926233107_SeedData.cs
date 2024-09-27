using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityPassGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "United Kingdom" },
                    { 2, "France" },
                    { 3, "Poland" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "DailyTransportCost", "Name" },
                values: new object[,]
                {
                    { 1, 1, 25m, "London" },
                    { 2, 2, 30m, "Paris" },
                    { 3, 3, 20m, "Krakow" }
                });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "CityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "London Eye", 40m },
                    { 2, 1, "Tate Gallery", 30m },
                    { 3, 1, "Tower of London", 35m },
                    { 4, 2, "Louvre Museum", 50m },
                    { 5, 2, "Eiffel Tower", 60m },
                    { 6, 2, "Arc de Triomphe", 35m },
                    { 7, 3, "Wawel Castle", 30m },
                    { 8, 3, "Sukiennice", 25m },
                    { 9, 3, "Mariacki Church", 20m }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttractionCityCard",
                keyColumns: new[] { "AttractionsId", "CityCardsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AttractionCityCard",
                keyColumns: new[] { "AttractionsId", "CityCardsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AttractionCityCard",
                keyColumns: new[] { "AttractionsId", "CityCardsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AttractionCityCard",
                keyColumns: new[] { "AttractionsId", "CityCardsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "AttractionCityCard",
                keyColumns: new[] { "AttractionsId", "CityCardsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "AttractionCityCard",
                keyColumns: new[] { "AttractionsId", "CityCardsId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "AttractionCityCard",
                keyColumns: new[] { "AttractionsId", "CityCardsId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "AttractionCityCard",
                keyColumns: new[] { "AttractionsId", "CityCardsId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CityCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CityCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CityCards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
