using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDangTuyenData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayUngTuyen",
                table: "UngTuyens",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "DangTuyens",
                columns: new[] { "Id", "DoanhNghiepId", "HinhThucDangTuyenId", "MoTa", "MucLuong", "NgayBatDau", "NgayDangKy", "NgayKetThuc", "NhanVienKiemDuyetId", "SoLuong", "TenViTri", "ThoiGianDangTuyen", "TrangThai", "UuDaiId" },
                values: new object[,]
                {
                    { 1, 1, 1, "    - Phát triển ứng dụng web với các Javascript Framework AngularJS hoặc ReactJS kết hợp với API Server.\r\n\r\n    - Phát triển thêm tính năng mới hoặc cải tiến tính năng sẵn có trên ứng dụng web theo yêu cầu.\r\n\r\n    - Tích hợp các thư viện của Third Party vào ứng dụng web.\r\n\r\n    - Tối ưu hiệu suất ứng dụng nhằm đảm bảo tính tương thích trên tất cả các thiết bị và trình duyệt khác nhau.", "10.000.000 - 15.000.000 VND", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Lập trình viên", 30, "Đang tuyển", null },
                    { 2, 2, 2, "    - Thực hiện các công việc kế toán theo quy định của pháp luật.\r\n\r\n    - Lập báo cáo tài chính hàng quý, hàng năm.\r\n\r\n    - Lập bảng cân đối kế toán, bảng cân đối kế toán.\r\n\r\n    - Lập báo cáo thuế hàng quý, hàng năm.\r\n\r\n    - Thực hiện các công việc khác theo sự phân công của cấp trên.", "5.000.000 - 7.000.000 VND", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Kế toán", 30, "Đang tuyển", null },
                    { 3, 3, 3, "    - Tìm kiếm khách hàng tiềm năng.\r\n\r\n    - Tư vấn sản phẩm, dịch vụ cho khách hàng.\r\n\r\n    - Chăm sóc khách hàng hiện tại.\r\n\r\n    - Thực hiện các công việc khác theo sự phân công của cấp trên.", "5.000.000 - 7.000.000 VND", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Nhân viên kinh doanh", 30, "Đang tuyển", null },
                    { 4, 3, 3, "    - Tìm kiếm khách hàng tiềm năng.\r\n\r\n    - Tư vấn sản phẩm, dịch vụ cho khách hàng.\r\n\r\n    - Chăm sóc khách hàng hiện tại.\r\n\r\n    - Thực hiện các công việc khác theo sự phân công của cấp trên.", "Thỏa thuận", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Nhân viên kinh doanh", 30, "Đang tuyển", null },
                    { 5, 3, 3, "    - Tìm kiếm khách hàng tiềm năng.\r\n\r\n    - Tư vấn sản phẩm, dịch vụ cho khách hàng.\r\n\r\n    - Chăm sóc khách hàng hiện tại.\r\n\r\n    - Thực hiện các công việc khác theo sự phân công của cấp trên.", "Thỏa thuận", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Nhân viên kinh doanh", 30, "Đang tuyển", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayUngTuyen",
                table: "UngTuyens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
