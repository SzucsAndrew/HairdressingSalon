using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdressingSalon.Data.Migrations
{
    public partial class RemovedColumnFormHairdresser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Hairdressers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Hairdressers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
