using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    ConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.ConfigId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "ConfigId");
                });

            migrationBuilder.CreateTable(
                name: "Ledgers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ledgers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LedgerCategories",
                columns: table => new
                {
                    LedgerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Goal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerCategories", x => new { x.LedgerCategoryId, x.LedgerId });
                    table.ForeignKey(
                        name: "FK_LedgerCategories_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalTable: "Ledgers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryGroups",
                columns: table => new
                {
                    CategoryGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LedgerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Goal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroups", x => new { x.CategoryGroupId, x.LedgerCategoryId, x.LedgerId });
                    table.ForeignKey(
                        name: "FK_CategoryGroups_LedgerCategories_LedgerCategoryId_LedgerId",
                        columns: x => new { x.LedgerCategoryId, x.LedgerId },
                        principalTable: "LedgerCategories",
                        principalColumns: new[] { "LedgerCategoryId", "LedgerId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroups_LedgerCategoryId_LedgerId",
                table: "CategoryGroups",
                columns: new[] { "LedgerCategoryId", "LedgerId" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroups_Name",
                table: "CategoryGroups",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerCategories_LedgerId",
                table: "LedgerCategories",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerCategories_Name",
                table: "LedgerCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_Name",
                table: "Ledgers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_UserId",
                table: "Ledgers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ConfigId",
                table: "Users",
                column: "ConfigId",
                unique: true,
                filter: "[ConfigId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryGroups");

            migrationBuilder.DropTable(
                name: "LedgerCategories");

            migrationBuilder.DropTable(
                name: "Ledgers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Configs");
        }
    }
}
