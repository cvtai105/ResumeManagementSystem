using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DoanhNghiepId", "MoTa", "TenViTri" },
                values: new object[] { 1, "    - Phát triển ứng dụng web với các Javascript Framework AngularJS hoặc ReactJS kết hợp với API Server.\r\n\r\n    - Phát triển thêm tính năng mới hoặc cải tiến tính năng sẵn có trên ứng dụng web theo yêu cầu.\r\n\r\n    - Tích hợp các thư viện của Third Party vào ứng dụng web.\r\n\r\n    - Tối ưu hiệu suất ứng dụng nhằm đảm bảo tính tương thích trên tất cả các thiết bị và trình duyệt khác nhau.", "Lập trình Game Unity Middle" });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 5,
                column: "TenViTri",
                value: "Nhân viên Marketting");

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 6,
                column: "DoanhNghiepId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 8,
                column: "DoanhNghiepId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 9,
                column: "DoanhNghiepId",
                value: 2);

            migrationBuilder.InsertData(
                table: "ThanhToans",
                columns: new[] { "Id", "DaThanhToan", "DangTuyenId", "HanThanhToan", "HinhThucThanhToanId", "SoTien" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5471), 1, 10000000 },
                    { 2, true, 2, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5473), 1, 5000000 },
                    { 3, true, 3, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5475), 1, 5000000 },
                    { 4, true, 4, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5476), 1, 5000000 },
                    { 5, true, 5, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5477), 1, 5000000 },
                    { 6, true, 6, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5478), 1, 5000000 },
                    { 7, true, 7, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5480), 1, 5000000 },
                    { 8, true, 8, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5481), 1, 5000000 },
                    { 9, true, 9, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5482), 1, 5000000 },
                    { 10, true, 10, new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5484), 1, 5000000 }
                });

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 4,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 5,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 6,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 7,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 8,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "UngTuyens",
                keyColumn: "Id",
                keyValue: 9,
                column: "NgayUngTuyen",
                value: new DateTime(2024, 7, 13, 3, 46, 27, 914, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "UngViens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AnhDaiDien", "HoTen" },
                values: new object[] { "1.jpg", "Nguyễn Văn An" });

            migrationBuilder.UpdateData(
                table: "UngViens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AnhDaiDien", "HoTen", "NgaySinh" },
                values: new object[] { "2.jpg", "Trần Văn Ba", new DateTime(2002, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UngViens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AnhDaiDien", "HoTen" },
                values: new object[] { "3.jpg", "Hồ Thị Giang" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ThanhToans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DoanhNghiepId", "MoTa", "TenViTri" },
                values: new object[] { 3, "    - Tìm kiếm khách hàng tiềm năng.\r\n\r\n    - Tư vấn sản phẩm, dịch vụ cho khách hàng.\r\n\r\n    - Chăm sóc khách hàng hiện tại.\r\n\r\n    - Thực hiện các công việc khác theo sự phân công của cấp trên.", "Nhân viên kinh doanh" });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 5,
                column: "TenViTri",
                value: "Nhân viên kinh doanh");

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 6,
                column: "DoanhNghiepId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 8,
                column: "DoanhNghiepId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 9,
                column: "DoanhNghiepId",
                value: 3);

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

            migrationBuilder.UpdateData(
                table: "UngViens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AnhDaiDien", "HoTen" },
                values: new object[] { "example.jpg", "Nguyễn Văn A" });

            migrationBuilder.UpdateData(
                table: "UngViens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AnhDaiDien", "HoTen", "NgaySinh" },
                values: new object[] { "example.jpg", "Nguyễn Văn B", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UngViens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AnhDaiDien", "HoTen" },
                values: new object[] { "example.jpg", "Nguyễn Văn C" });
        }
    }
}
