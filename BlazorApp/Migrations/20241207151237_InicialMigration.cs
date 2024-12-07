using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false, defaultValue: "Gardener"),
                    Login = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Species = table.Column<string>(type: "text", nullable: false),
                    PlantedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TreeLocationId = table.Column<int>(type: "integer", nullable: true),
                    TreeStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.TreeId);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    FieldId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EmployeeResponsibleEmployeeId = table.Column<int>(type: "integer", nullable: true),
                    EmployeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.FieldId);
                    table.ForeignKey(
                        name: "FK_Fields_Employees_EmployeeResponsibleEmployeeId",
                        column: x => x.EmployeeResponsibleEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TreeId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Trees_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Trees",
                        principalColumn: "TreeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreeHistories",
                columns: table => new
                {
                    TreeHistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeHistories", x => x.TreeHistoryId);
                    table.ForeignKey(
                        name: "FK_TreeHistories_Trees_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Trees",
                        principalColumn: "TreeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionFields",
                columns: table => new
                {
                    SectionFieldId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FieldId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeResponsibleEmployeeId = table.Column<int>(type: "integer", nullable: true),
                    EmployeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionFields", x => x.SectionFieldId);
                    table.ForeignKey(
                        name: "FK_SectionFields_Employees_EmployeeResponsibleEmployeeId",
                        column: x => x.EmployeeResponsibleEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_SectionFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreeBlocks",
                columns: table => new
                {
                    BlockId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    RowSpacing = table.Column<double>(type: "double precision", nullable: false),
                    ColSpacing = table.Column<double>(type: "double precision", nullable: false),
                    LocationCount = table.Column<int>(type: "integer", nullable: false),
                    SectionFieldId = table.Column<int>(type: "integer", nullable: true),
                    FieldId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeBlocks", x => x.BlockId);
                    table.ForeignKey(
                        name: "FK_TreeBlocks_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "FieldId");
                    table.ForeignKey(
                        name: "FK_TreeBlocks_SectionFields_SectionFieldId",
                        column: x => x.SectionFieldId,
                        principalTable: "SectionFields",
                        principalColumn: "SectionFieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreeLocations",
                columns: table => new
                {
                    TreeLocationId = table.Column<int>(type: "integer", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    RowId = table.Column<string>(type: "text", nullable: false),
                    ColId = table.Column<string>(type: "text", nullable: false),
                    QRCode = table.Column<string>(type: "text", nullable: false),
                    LocationTreeStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeLocations", x => x.TreeLocationId);
                    table.ForeignKey(
                        name: "FK_TreeLocations_TreeBlocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "TreeBlocks",
                        principalColumn: "BlockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreeLocations_Trees_TreeLocationId",
                        column: x => x.TreeLocationId,
                        principalTable: "Trees",
                        principalColumn: "TreeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationHistories",
                columns: table => new
                {
                    LocationHistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreeLocationId = table.Column<int>(type: "integer", nullable: false),
                    ChangeDescription = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationHistories", x => x.LocationHistoryId);
                    table.ForeignKey(
                        name: "FK_LocationHistories_TreeLocations_TreeLocationId",
                        column: x => x.TreeLocationId,
                        principalTable: "TreeLocations",
                        principalColumn: "TreeLocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_EmployeeId",
                table: "EmployeeTasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_TreeId",
                table: "EmployeeTasks",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_EmployeeResponsibleEmployeeId",
                table: "Fields",
                column: "EmployeeResponsibleEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationHistories_TreeLocationId",
                table: "LocationHistories",
                column: "TreeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionFields_EmployeeResponsibleEmployeeId",
                table: "SectionFields",
                column: "EmployeeResponsibleEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionFields_FieldId",
                table: "SectionFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeBlocks_FieldId",
                table: "TreeBlocks",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeBlocks_SectionFieldId",
                table: "TreeBlocks",
                column: "SectionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeHistories_TreeId",
                table: "TreeHistories",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeLocations_BlockId",
                table: "TreeLocations",
                column: "BlockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTasks");

            migrationBuilder.DropTable(
                name: "LocationHistories");

            migrationBuilder.DropTable(
                name: "TreeHistories");

            migrationBuilder.DropTable(
                name: "TreeLocations");

            migrationBuilder.DropTable(
                name: "TreeBlocks");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "SectionFields");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
