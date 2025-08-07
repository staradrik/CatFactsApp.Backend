using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatFactsApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CatFact = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Query = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GifUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchHistory");
        }
    }
}
