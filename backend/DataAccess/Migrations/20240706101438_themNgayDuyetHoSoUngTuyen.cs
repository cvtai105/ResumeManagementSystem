using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class themNgayDuyetHoSoUngTuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayKiemDuyen",
                table: "UngTuyens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayKiemDuyen",
                value: null);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayKiemDuyen",
                value: null);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayKiemDuyen",
                value: null);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 4,
                column: "NgayKiemDuyen",
                value: null);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 5,
                column: "NgayKiemDuyen",
                value: null);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 6,
                column: "NgayKiemDuyen",
                value: null);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 7,
                column: "NgayKiemDuyen",
                value: null);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 8,
                column: "NgayKiemDuyen",
                value: null);

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 9,
                column: "NgayKiemDuyen",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayKiemDuyen",
                table: "UngTuyens");
        }
    }
}
