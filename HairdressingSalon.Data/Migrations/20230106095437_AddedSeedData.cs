using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdressingSalon.Data.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OpeningHours",
                columns: new[] { "Id", "CloseTime", "DayOfWeek", "IsClosed", "OpenTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 17, 0, 0, 0), 1, false, new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 17, 0, 0, 0), 2, false, new TimeSpan(0, 8, 0, 0, 0) },
                    { 3, new TimeSpan(0, 17, 0, 0, 0), 3, false, new TimeSpan(0, 8, 0, 0, 0) },
                    { 4, new TimeSpan(0, 17, 0, 0, 0), 4, false, new TimeSpan(0, 8, 0, 0, 0) },
                    { 5, new TimeSpan(0, 17, 0, 0, 0), 5, false, new TimeSpan(0, 8, 0, 0, 0) },
                    { 6, new TimeSpan(0), 6, true, new TimeSpan(0) },
                    { 7, new TimeSpan(0), 7, true, new TimeSpan(0) }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Duration", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 15, 0, 0), true, "Haircut", 3000m },
                    { 2, new TimeSpan(0, 0, 25, 0, 0), true, "Haircut and hair drying", 4500m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
