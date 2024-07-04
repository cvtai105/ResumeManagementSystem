using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUngTuyenData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "UngTuyens");

            migrationBuilder.AddColumn<string>(
                name: "TenTieuChi",
                table: "TieuChiTuyenDungs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TieuChiTuyenDungs",
                columns: new[] { "Id", "DangTuyenId", "MoTa", "TenTieuChi" },
                values: new object[,]
                {
                    { 1, 1, "30 Năm kinh nghiệm làm việc trong lĩnh vực lập trình", "Kinh Nghiệm Làm Việc" },
                    { 2, 2, "Có kiến thức vững về kế toán", "Kỹ năng kế toán" },
                    { 3, 3, "Có kiến thức vững về kinh doanh", "Kỹ năng kinh doanh" },
                    { 4, 4, "Có kiến thức vững về kinh doanh", "Kỹ năng kinh doanh" },
                    { 5, 5, "Có kiến thức vững về kinh doanh", "Kỹ năng kinh doanh" },
                    { 6, 1, "20-25 tuổi", "Độ tuổi" },
                    { 7, 2, "20-25 tuổi", "Độ tuổi" },
                    { 8, 3, "20-25 tuổi", "Độ tuổi" },
                    { 9, 4, "20-25 tuổi", "Độ tuổi" },
                    { 10, 5, "20-25 tuổi", "Độ tuổi" },
                    { 11, 1, "Đại học", "Trình độ học vấn" },
                    { 12, 2, "Đại học", "Trình độ học vấn" },
                    { 13, 3, "Đại học", "Trình độ học vấn" },
                    { 14, 4, "Đại học", "Trình độ học vấn" },
                    { 15, 5, "Đại học", "Trình độ học vấn" }
                });

            migrationBuilder.InsertData(
                table: "UngTuyens",
                columns: new[] { "Id", "DangTuyenId", "DanhGia", "NgayUngTuyen", "NhanVienKiemDuyenId", "UngVienId" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, 2, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 3, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 4, 4, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 5, 5, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "UngViens",
                columns: new[] { "Id", "AnhDaiDien", "CCCD", "Cv", "DiaChi", "Email", "GioiTinh", "HoTen", "MatKhau", "NgaySinh", "SoDienThoai", "TrinhDoChuyenMon", "TrinhDoHocVan" },
                values: new object[] { 3, "example.jpg", null, "example.jpg", "Hà Nội", "ungvien3@email.com", null, "Nguyễn Văn C", "123456", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "CNTT", "Đại học FPT" });

            migrationBuilder.InsertData(
                table: "HoSoUngTuyens",
                columns: new[] { "Id", "FileHoSo", "MoTa", "TenHoSo", "UngTuyenId" },
                values: new object[,]
                {
                    { 1, "example.pdf", "CV", "CV", 1 },
                    { 2, "example.pdf", "CV", "CV", 2 },
                    { 3, "example.pdf", "CV", "CV", 3 },
                    { 4, "example.pdf", "CV", "CV", 4 },
                    { 5, "example.pdf", "CV", "CV", 5 }
                });

            migrationBuilder.InsertData(
                table: "UngTuyens",
                columns: new[] { "Id", "DangTuyenId", "DanhGia", "NgayUngTuyen", "NhanVienKiemDuyenId", "UngVienId" },
                values: new object[,]
                {
                    { 6, 1, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 7, 2, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 8, 3, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 9, 4, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "HoSoUngTuyens",
                columns: new[] { "Id", "FileHoSo", "MoTa", "TenHoSo", "UngTuyenId" },
                values: new object[,]
                {
                    { 6, "example.pdf", "CV", "CV", 6 },
                    { 7, "example.pdf", "CV", "CV", 7 },
                    { 8, "example.pdf", "CV", "CV", 8 },
                    { 9, "example.pdf", "CV", "CV", 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HoSoUngTuyens",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TieuChiTuyenDungs",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UngViens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "TenTieuChi",
                table: "TieuChiTuyenDungs");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "UngTuyens",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
