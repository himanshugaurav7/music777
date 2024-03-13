using System;
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace MusicHub.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicHubTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicCDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicCDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicCDId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_MusicCDs_MusicCDId",
                        column: x => x.MusicCDId,
                        principalTable: "MusicCDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MusicCDs",
                columns: new[] { "Id", "Artist", "Genre", "Price", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { 1, "Artist A", "Rock", 20m, 100, "Album1" },
                    { 2, "Artist B", "POP", 15m, 75, "Ben Hits" },
                    { 3, "Artist C", "Jazz", 25m, 50, "Jazz Fashion" },
                    { 4, "Artist D", "Classical", 30m, 120, "Classic Fusion" },
                    { 5, "Artist E", "Electronic", 18m, 80, "Electronic Beats" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "MusicCDId", "OrderDate", "Quantity", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 41m, 101 },
                    { 2, 3, new DateTime(2024, 3, 5, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 25m, 102 },
                    { 3, 2, new DateTime(2024, 3, 5, 14, 20, 0, 0, DateTimeKind.Unspecified), 3, 47m, 103 },
                    { 4, 4, new DateTime(2024, 2, 5, 15, 55, 0, 0, DateTimeKind.Unspecified), 1, 30m, 104 },
                    { 5, 5, new DateTime(2024, 3, 5, 17, 10, 0, 0, DateTimeKind.Unspecified), 2, 37m, 105 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MusicCDId",
                table: "Orders",
                column: "MusicCDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "MusicCDs");
        }
    }
}
