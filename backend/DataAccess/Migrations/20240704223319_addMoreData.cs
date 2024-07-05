using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "DoanhNghieps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MucLuong",
                table: "DangTuyens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangTuyens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "DangTuyens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.InsertData(
                table: "DoanhNghieps",
                columns: new[] { "Id", "DiaChi", "DienThoai", "Email", "Image", "MaSoThue", "MatKhau", "NgayDangKy", "NhanVienDangKyId", "TenDoanhNghiep", "XacNhan" },
                values: new object[,]
                {
                    { 2, null, "0123456789", "doanhnghiep2@email.com", null, "123456", "123456", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cty TNHH XYZ", null },
                    { 3, null, "0123456789", "doanhnghiep3@email.com", null, "123456", "123456", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cty TNHH KLM", null }
                });

            migrationBuilder.InsertData(
                table: "UngViens",
                columns: new[] { "Id", "AnhDaiDien", "CCCD", "Cv", "DiaChi", "Email", "GioiTinh", "HoTen", "MatKhau", "NgaySinh", "SoDienThoai", "TrinhDoChuyenMon", "TrinhDoHocVan" },
                values: new object[] { 2, "example.jpg", null, "example.jpg", "Hà Nội", "ungvien2@email.com", null, "Nguyễn Văn B", "123456", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "CNTT", "Đại học FPT" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UngViens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "DoanhNghieps");

            migrationBuilder.DropColumn(
                name: "MucLuong",
                table: "DangTuyens");

            migrationBuilder.DropColumn(
                name: "NgayDangKy",
                table: "DangTuyens");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "DangTuyens");
        }
    }
}
