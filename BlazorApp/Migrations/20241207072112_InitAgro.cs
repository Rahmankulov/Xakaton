using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class InitAgro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false, defaultValue: 3)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    FieldId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.FieldId);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Species = table.Column<string>(type: "text", nullable: false),
                    PlantedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TreeLocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.TreeId);
                });

            migrationBuilder.CreateTable(
                name: "TreeBlocks",
                columns: table => new
                {
                    BlockId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeBlocks", x => x.BlockId);
                    table.ForeignKey(
                        name: "FK_TreeBlocks_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
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
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tasks_Trees_TreeId",
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
                name: "TreeLocations",
                columns: table => new
                {
                    TreeLocationId = table.Column<int>(type: "integer", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
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
                name: "IX_LocationHistories_TreeLocationId",
                table: "LocationHistories",
                column: "TreeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TreeId",
                table: "Tasks",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeBlocks_FieldId",
                table: "TreeBlocks",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeHistories_TreeId",
                table: "TreeHistories",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeLocations_BlockId",
                table: "TreeLocations",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeLocations_Latitude_Longitude",
                table: "TreeLocations",
                columns: new[] { "Latitude", "Longitude" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationHistories");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TreeHistories");

            migrationBuilder.DropTable(
                name: "TreeLocations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TreeBlocks");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }
    }
}
