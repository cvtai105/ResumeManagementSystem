using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMoreDataa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MatKhau",
                table: "UngViens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DangTuyens",
                columns: new[] { "Id", "ChuyenNganh", "DoanhNghiepId", "HinhThucDangTuyenId", "KhuVuc", "MoTa", "MucLuong", "NgayBatDau", "NgayDangKy", "NgayKetThuc", "NhanVienKiemDuyetId", "SoLuong", "TenViTri", "ThoiGianDangTuyen", "TrangThai", "UuDaiId" },
                values: new object[,]
                {
                    { 6, "Kinh Doanh", 3, 3, "Hồ Chi Minh", "    - Tìm kiếm khách hàng tiềm năng.\r\n\r\n    - Tư vấn sản phẩm, dịch vụ cho khách hàng.\r\n\r\n    - Chăm sóc khách hàng hiện tại.\r\n\r\n    - Thực hiện các công việc khác theo sự phân công của cấp trên.", "Thỏa thuận", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Nhân viên marketing", 30, "Đang tuyển", null },
                    { 7, "Kinh Doanh", 3, 3, "Hồ Chi Minh", "    - Full stack .NET Developer.\r\n\r\n    - Fix bug, maintain, develop new features.\r\n\r\n    - Make sure the code quality, performance, and maintainability.\r\n\r\n    - and other tasks assigned by the project manager.", "Thỏa thuận", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Senior .NET Developer", 30, "Đang tuyển", null },
                    { 8, "Kinh Doanh", 3, 3, "Hồ Chi Minh", "    - Full stack .NET Developer.\r\n\r\n    - Fix bug, maintain, develop new features.\r\n\r\n    - Make sure the code quality, performance, and maintainability.\r\n\r\n    - and other tasks assigned by the project manager.", "3.000.000 VND", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Intern .NET Developer", 30, "Đang tuyển", null },
                    { 9, "Kinh Doanh", 3, 3, "Hồ Chi Minh", "    - Full stack .NET Developer.\r\n\r\n    - Fix bug, maintain, develop new features.\r\n\r\n    - Make sure the code quality, performance, and maintainability.\r\n\r\n    - and other tasks assigned by the project manager.", "30M - 40M", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Kỹ sư thiết kế đồ họa", 30, "Đang tuyển", null },
                    { 10, "Kinh Doanh", 3, 3, "Hồ Chi Minh", "    - Full stack .NET Developer.\r\n\r\n    - Fix bug, maintain, develop new features.\r\n\r\n    - Make sure the code quality, performance, and maintainability.\r\n\r\n    - and other tasks assigned by the project manager.", "30M - 40M", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Kỹ sư thiết kế đồ họa", 30, "Đang tuyển", null }
                });

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayDangKy",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayDangKy",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayDangKy",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 4,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 5,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 6,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 7,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 8,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 9,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "MatKhau",
                table: "UngViens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "NgayBatDau", "NgayDangKy", "NgayKetThuc" },
                values: new object[] { new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayDangKy",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayDangKy",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayDangKy",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 4,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 5,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 6,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 7,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 8,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 9,
                column: "NgayUngTuyen",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
