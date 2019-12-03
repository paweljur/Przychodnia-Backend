using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaBackend.EntityFrameworkCore.Migrations
{
    public partial class AppointmentState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAttended",
                table: "Appointment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Appointment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAttended",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Appointment");
        }
    }
}
