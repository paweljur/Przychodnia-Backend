using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaBackend.EntityFrameworkCore.Migrations
{
    public partial class LaborantInResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LaborantId",
                table: "LabTestResults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabTestResults_LaborantId",
                table: "LabTestResults",
                column: "LaborantId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTestResults_Users_LaborantId",
                table: "LabTestResults",
                column: "LaborantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTestResults_Users_LaborantId",
                table: "LabTestResults");

            migrationBuilder.DropIndex(
                name: "IX_LabTestResults_LaborantId",
                table: "LabTestResults");

            migrationBuilder.DropColumn(
                name: "LaborantId",
                table: "LabTestResults");
        }
    }
}
