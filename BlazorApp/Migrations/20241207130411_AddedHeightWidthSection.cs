using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedHeightWidthSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QRCode",
                table: "TreeLocations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ColSpacing",
                table: "TreeBlocks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "TreeBlocks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "LocationCount",
                table: "TreeBlocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "RowSpacing",
                table: "TreeBlocks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "TreeBlocks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QRCode",
                table: "TreeLocations");

            migrationBuilder.DropColumn(
                name: "ColSpacing",
                table: "TreeBlocks");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "TreeBlocks");

            migrationBuilder.DropColumn(
                name: "LocationCount",
                table: "TreeBlocks");

            migrationBuilder.DropColumn(
                name: "RowSpacing",
                table: "TreeBlocks");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "TreeBlocks");
        }
    }
}
