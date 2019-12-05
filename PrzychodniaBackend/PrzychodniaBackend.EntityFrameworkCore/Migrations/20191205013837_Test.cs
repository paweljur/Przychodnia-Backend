using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaBackend.EntityFrameworkCore.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTestResult_LabTestOrders_LabTestOrderId",
                table: "LabTestResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabTestResult",
                table: "LabTestResult");

            migrationBuilder.RenameTable(
                name: "LabTestResult",
                newName: "LabTestResults");

            migrationBuilder.RenameIndex(
                name: "IX_LabTestResult_LabTestOrderId",
                table: "LabTestResults",
                newName: "IX_LabTestResults_LabTestOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabTestResults",
                table: "LabTestResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTestResults_LabTestOrders_LabTestOrderId",
                table: "LabTestResults",
                column: "LabTestOrderId",
                principalTable: "LabTestOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTestResults_LabTestOrders_LabTestOrderId",
                table: "LabTestResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabTestResults",
                table: "LabTestResults");

            migrationBuilder.RenameTable(
                name: "LabTestResults",
                newName: "LabTestResult");

            migrationBuilder.RenameIndex(
                name: "IX_LabTestResults_LabTestOrderId",
                table: "LabTestResult",
                newName: "IX_LabTestResult_LabTestOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabTestResult",
                table: "LabTestResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTestResult_LabTestOrders_LabTestOrderId",
                table: "LabTestResult",
                column: "LabTestOrderId",
                principalTable: "LabTestOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
