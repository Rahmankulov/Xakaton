using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDataTypesOnTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColId",
                table: "Trees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RowId",
                table: "Trees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "SectionFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeResponsibleEmployeeId",
                table: "SectionFields",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionFields_EmployeeResponsibleEmployeeId",
                table: "SectionFields",
                column: "EmployeeResponsibleEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionFields_Employees_EmployeeResponsibleEmployeeId",
                table: "SectionFields",
                column: "EmployeeResponsibleEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionFields_Employees_EmployeeResponsibleEmployeeId",
                table: "SectionFields");

            migrationBuilder.DropIndex(
                name: "IX_SectionFields_EmployeeResponsibleEmployeeId",
                table: "SectionFields");

            migrationBuilder.DropColumn(
                name: "ColId",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "RowId",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "SectionFields");

            migrationBuilder.DropColumn(
                name: "EmployeeResponsibleEmployeeId",
                table: "SectionFields");
        }
    }
}
