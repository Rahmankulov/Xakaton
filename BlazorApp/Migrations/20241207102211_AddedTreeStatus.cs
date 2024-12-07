using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedTreeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColId",
                table: "Trees");

            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "Trees",
                newName: "TreeStatus");

            migrationBuilder.AlterColumn<int>(
                name: "TreeLocationId",
                table: "Trees",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TreeStatus",
                table: "Trees",
                newName: "RowId");

            migrationBuilder.AlterColumn<int>(
                name: "TreeLocationId",
                table: "Trees",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColId",
                table: "Trees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
