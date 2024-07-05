using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addtrangthaiungtuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "UngTuyens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrangThai",
                value: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrangThai",
                value: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrangThai",
                value: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 4,
                column: "TrangThai",
                value: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 5,
                column: "TrangThai",
                value: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 6,
                column: "TrangThai",
                value: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 7,
                column: "TrangThai",
                value: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 8,
                column: "TrangThai",
                value: "");

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 9,
                column: "TrangThai",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "UngTuyens");
        }
    }
}
