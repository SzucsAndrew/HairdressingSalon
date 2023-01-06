using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdressingSalon.Data.Migrations
{
    public partial class AddedSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeSpan(0), new TimeSpan(0) });

            migrationBuilder.UpdateData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeSpan(0), new TimeSpan(0) });
        }
    }
}
