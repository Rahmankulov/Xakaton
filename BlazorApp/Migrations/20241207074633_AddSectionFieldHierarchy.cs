using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSectionFieldHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionFieldId",
                table: "TreeBlocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SectionFields",
                columns: table => new
                {
                    SectionFieldId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionFields", x => x.SectionFieldId);
                    table.ForeignKey(
                        name: "FK_SectionFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeBlocks_SectionFieldId",
                table: "TreeBlocks",
                column: "SectionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionFields_FieldId",
                table: "SectionFields",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreeBlocks_SectionFields_SectionFieldId",
                table: "TreeBlocks",
                column: "SectionFieldId",
                principalTable: "SectionFields",
                principalColumn: "SectionFieldId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreeBlocks_SectionFields_SectionFieldId",
                table: "TreeBlocks");

            migrationBuilder.DropTable(
                name: "SectionFields");

            migrationBuilder.DropIndex(
                name: "IX_TreeBlocks_SectionFieldId",
                table: "TreeBlocks");

            migrationBuilder.DropColumn(
                name: "SectionFieldId",
                table: "TreeBlocks");
        }
    }
}
