using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDataTypesOnTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TreeLocations_Latitude_Longitude",
                table: "TreeLocations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TreeLocations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TreeLocations");

            migrationBuilder.AddColumn<string>(
                name: "ColId",
                table: "TreeLocations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RowId",
                table: "TreeLocations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColId",
                table: "TreeLocations");

            migrationBuilder.DropColumn(
                name: "RowId",
                table: "TreeLocations");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "TreeLocations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "TreeLocations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_TreeLocations_Latitude_Longitude",
                table: "TreeLocations",
                columns: new[] { "Latitude", "Longitude" },
                unique: true);
        }
    }
}
