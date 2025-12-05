using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkyWorkTask.Migrations
{
    /// <inheritdoc />
    public partial class CreatePengajuanKredit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PengajuanKredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Plafon = table.Column<int>(type: "integer", nullable: false),
                    Bunga = table.Column<decimal>(type: "numeric", nullable: false),
                    Tenor = table.Column<int>(type: "integer", nullable: false),
                    Angsuran = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PengajuanKredits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_plafon",
                table: "PengajuanKredits",
                column: "Plafon");

            migrationBuilder.CreateIndex(
                name: "idx_Tenor",
                table: "PengajuanKredits",
                column: "Tenor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PengajuanKredits");
        }
    }
}
