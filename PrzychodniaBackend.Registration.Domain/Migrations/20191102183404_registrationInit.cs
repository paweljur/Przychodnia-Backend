using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaBackend.Registration.Domain.Migrations
{
    public partial class registrationInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Registration");

            migrationBuilder.CreateTable(
                name: "Appointments",
                schema: "Registration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTimeOffset>(nullable: false),
                    Doctor = table.Column<string>(nullable: false),
                    Patient = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments",
                schema: "Registration");
        }
    }
}
