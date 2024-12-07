using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "Fields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeResponsibleEmployeeId",
                table: "Fields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_EmployeeResponsibleEmployeeId",
                table: "Fields",
                column: "EmployeeResponsibleEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Employees_EmployeeResponsibleEmployeeId",
                table: "Fields",
                column: "EmployeeResponsibleEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Employees_EmployeeResponsibleEmployeeId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_EmployeeResponsibleEmployeeId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "EmployeeResponsibleEmployeeId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Employees");
        }
    }
}
