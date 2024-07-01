using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Ver1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HinhThucDangTuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucDangTuyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucThanhToans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucThanhToans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UngViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrinhDoHocVan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoChuyenMon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UngViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoanhNghieps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDoanhNghiep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienDangKyId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVien = table.Column<int>(type: "int", nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhNghieps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoanhNghieps_NhanViens_NhanVien",
                        column: x => x.NhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UuDais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoanhNghiepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UuDais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UuDais_DoanhNghieps_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "DoanhNghieps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangTuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenViTri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianDangTuyen = table.Column<int>(type: "int", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoanhNghiepId = table.Column<int>(type: "int", nullable: false),
                    NhanVienKiemDuyetId = table.Column<int>(type: "int", nullable: true),
                    UuDaiId = table.Column<int>(type: "int", nullable: true),
                    HinhThucDangTuyenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangTuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DangTuyens_DoanhNghieps_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "DoanhNghieps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangTuyens_HinhThucDangTuyens_HinhThucDangTuyenId",
                        column: x => x.HinhThucDangTuyenId,
                        principalTable: "HinhThucDangTuyens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DangTuyens_NhanViens_NhanVienKiemDuyetId",
                        column: x => x.NhanVienKiemDuyetId,
                        principalTable: "NhanViens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DangTuyens_UuDais_UuDaiId",
                        column: x => x.UuDaiId,
                        principalTable: "UuDais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThanhToans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoTien = table.Column<int>(type: "int", nullable: false),
                    DaThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    HanThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DangTuyenId = table.Column<int>(type: "int", nullable: false),
                    HinhThucThanhToanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhToans_DangTuyens_DangTuyenId",
                        column: x => x.DangTuyenId,
                        principalTable: "DangTuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                        column: x => x.HinhThucThanhToanId,
                        principalTable: "HinhThucThanhToans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TieuChiTuyenDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DangTuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieuChiTuyenDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TieuChiTuyenDungs_DangTuyens_DangTuyenId",
                        column: x => x.DangTuyenId,
                        principalTable: "DangTuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UngTuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayUngTuyen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DangTuyenId = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienKiemDuyenId = table.Column<int>(type: "int", nullable: true),
                    UngVienId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UngTuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UngTuyens_DangTuyens_DangTuyenId",
                        column: x => x.DangTuyenId,
                        principalTable: "DangTuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UngTuyens_NhanViens_NhanVienKiemDuyenId",
                        column: x => x.NhanVienKiemDuyenId,
                        principalTable: "NhanViens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UngTuyens_UngViens_UngVienId",
                        column: x => x.UngVienId,
                        principalTable: "UngViens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DotThanhToans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoTien = table.Column<int>(type: "int", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhanVienThanhToanId = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhToanId = table.Column<int>(type: "int", nullable: false),
                    HinhThucThanhToanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DotThanhToans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DotThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                        column: x => x.HinhThucThanhToanId,
                        principalTable: "HinhThucThanhToans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DotThanhToans_NhanViens_NhanVienThanhToanId",
                        column: x => x.NhanVienThanhToanId,
                        principalTable: "NhanViens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DotThanhToans_ThanhToans_ThanhToanId",
                        column: x => x.ThanhToanId,
                        principalTable: "ThanhToans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoUngTuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UngTuyenId = table.Column<int>(type: "int", nullable: false),
                    TenHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoUngTuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoUngTuyens_UngTuyens_UngTuyenId",
                        column: x => x.UngTuyenId,
                        principalTable: "UngTuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DoanhNghieps",
                columns: new[] { "Id", "DienThoai", "Email", "MaSoThue", "MatKhau", "NgayDangKy", "NhanVien", "NhanVienDangKyId", "TenDoanhNghiep" },
                values: new object[] { 1, "0123456789", "doanhnghiep@email.com", "123456", "123456", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Cty TNHH ABC" });

            migrationBuilder.InsertData(
                table: "HinhThucDangTuyens",
                columns: new[] { "Id", "MoTa", "TenHinhThuc" },
                values: new object[,]
                {
                    { 1, "Đăng tuyển qua báo giấy", "Báo Giấy" },
                    { 2, "Đăng tuyển qua website công ty", "Website Công Ty" },
                    { 3, "Đăng tuyển qua các banner quảng cáo", "Banner Quảng cáo" }
                });

            migrationBuilder.InsertData(
                table: "HinhThucThanhToans",
                columns: new[] { "Id", "MoTa", "TenHinhThuc" },
                values: new object[,]
                {
                    { 1, "Thanh toán qua chuyển khoản", "Chuyển khoản" },
                    { 2, "Thanh toán bằng tiền mặt", "Tiền mặt" }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "AnhDaiDien", "Email", "MatKhau", "TenNhanVien" },
                values: new object[] { 1, "example.jpg", "nhanvien@email.com", "123456", "Nguyễn Văn B" });

            migrationBuilder.InsertData(
                table: "UngViens",
                columns: new[] { "Id", "AnhDaiDien", "CCCD", "Cv", "DiaChi", "Email", "GioiTinh", "HoTen", "MatKhau", "NgaySinh", "SoDienThoai", "TrinhDoChuyenMon", "TrinhDoHocVan" },
                values: new object[] { 1, "example.jpg", null, "example.jpg", "Hà Nội", "ungvien@email.com", null, "Nguyễn Văn A", "123456", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "CNTT", "Đại học FPT" });

            migrationBuilder.CreateIndex(
                name: "IX_DangTuyens_DoanhNghiepId",
                table: "DangTuyens",
                column: "DoanhNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_DangTuyens_HinhThucDangTuyenId",
                table: "DangTuyens",
                column: "HinhThucDangTuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_DangTuyens_NhanVienKiemDuyetId",
                table: "DangTuyens",
                column: "NhanVienKiemDuyetId");

            migrationBuilder.CreateIndex(
                name: "IX_DangTuyens_UuDaiId",
                table: "DangTuyens",
                column: "UuDaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghieps_NhanVien",
                table: "DoanhNghieps",
                column: "NhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DotThanhToans_HinhThucThanhToanId",
                table: "DotThanhToans",
                column: "HinhThucThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_DotThanhToans_NhanVienThanhToanId",
                table: "DotThanhToans",
                column: "NhanVienThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_DotThanhToans_ThanhToanId",
                table: "DotThanhToans",
                column: "ThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoUngTuyens_UngTuyenId",
                table: "HoSoUngTuyens",
                column: "UngTuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_DangTuyenId",
                table: "ThanhToans",
                column: "DangTuyenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_HinhThucThanhToanId",
                table: "ThanhToans",
                column: "HinhThucThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiTuyenDungs_DangTuyenId",
                table: "TieuChiTuyenDungs",
                column: "DangTuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_UngTuyens_DangTuyenId",
                table: "UngTuyens",
                column: "DangTuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_UngTuyens_NhanVienKiemDuyenId",
                table: "UngTuyens",
                column: "NhanVienKiemDuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_UngTuyens_UngVienId",
                table: "UngTuyens",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_UuDais_DoanhNghiepId",
                table: "UuDais",
                column: "DoanhNghiepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DotThanhToans");

            migrationBuilder.DropTable(
                name: "HoSoUngTuyens");

            migrationBuilder.DropTable(
                name: "TieuChiTuyenDungs");

            migrationBuilder.DropTable(
                name: "ThanhToans");

            migrationBuilder.DropTable(
                name: "UngTuyens");

            migrationBuilder.DropTable(
                name: "HinhThucThanhToans");

            migrationBuilder.DropTable(
                name: "DangTuyens");

            migrationBuilder.DropTable(
                name: "UngViens");

            migrationBuilder.DropTable(
                name: "HinhThucDangTuyens");

            migrationBuilder.DropTable(
                name: "UuDais");

            migrationBuilder.DropTable(
                name: "DoanhNghieps");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
