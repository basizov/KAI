using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KAI.Storage.Data.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    extension = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    size = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_files", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_files_extension",
                table: "files",
                column: "extension");

            migrationBuilder.CreateIndex(
                name: "ix_files_is_deleted",
                table: "files",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_files_name",
                table: "files",
                column: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
