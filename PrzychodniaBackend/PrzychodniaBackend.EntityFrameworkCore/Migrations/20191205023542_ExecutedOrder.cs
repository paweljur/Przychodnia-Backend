using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaBackend.EntityFrameworkCore.Migrations
{
    public partial class ExecutedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExecuted",
                table: "LabTestOrders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExecuted",
                table: "LabTestOrders");
        }
    }
}
