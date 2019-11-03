using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaBackend.Registration.Domain.Migrations
{
    public partial class patientValueObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patient",
                schema: "Registration",
                table: "Appointments");

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                schema: "Registration",
                table: "Appointments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "Registration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                schema: "Registration",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patient_PatientId",
                schema: "Registration",
                table: "Appointments",
                column: "PatientId",
                principalSchema: "Registration",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patient_PatientId",
                schema: "Registration",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId",
                schema: "Registration",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "Registration",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                schema: "Registration",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
