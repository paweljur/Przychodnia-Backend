using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaBackend.Registration.Domain.Migrations
{
    public partial class doctorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctor",
                schema: "Registration",
                table: "Appointments");

            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                schema: "Registration",
                table: "Appointments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "Registration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                schema: "Registration",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                schema: "Registration",
                table: "Appointments",
                column: "DoctorId",
                principalSchema: "Registration",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                schema: "Registration",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                schema: "Registration",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                schema: "Registration",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                schema: "Registration",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
