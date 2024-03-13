using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicHub.Migrations
{
    /// <inheritdoc />
    public partial class Addusertodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "MusicCDs",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 20);

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 15);

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 25);

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 30);

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalPrice",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalPrice",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "TotalPrice",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "TotalPrice",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "TotalPrice",
                value: 37);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MusicCDs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 20m);

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 25m);

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "MusicCDs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 18m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalPrice",
                value: 41m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalPrice",
                value: 25m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "TotalPrice",
                value: 47m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "TotalPrice",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "TotalPrice",
                value: 37m);
        }
    }
}
