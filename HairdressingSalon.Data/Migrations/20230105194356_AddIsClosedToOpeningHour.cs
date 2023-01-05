using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdressingSalon.Data.Migrations
{
    public partial class AddIsClosedToOpeningHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "OpeningHours",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "OpeningHours");
        }
    }
}
