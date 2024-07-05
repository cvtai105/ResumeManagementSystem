using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entities;

namespace DataAccess.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<DangTuyen> DangTuyens { get; set; }
    public DbSet<DoanhNghiep> DoanhNghieps { get; set; }
    public DbSet<DotThanhToan> DotThanhToans { get; set; }
    public DbSet<HinhThucDangTuyen> HinhThucDangTuyens { get; set; }
    public DbSet<HinhThucThanhToan> HinhThucThanhToans { get; set; }
    public DbSet<HoSoUngTuyen> HoSoUngTuyens { get; set; }
    public DbSet<NhanVien> NhanViens { get; set; }
    public DbSet<ThanhToan> ThanhToans { get; set; }
    public DbSet<TieuChiTuyenDung> TieuChiTuyenDungs { get; set; }
    public DbSet<UngTuyen> UngTuyens { get; set; }
    public DbSet<UuDai> UuDais { get; set; }
    public DbSet<UngVien> UngViens { get; set; } 
    public DbSet<ExampleDTO> ExampleDTOs { get; set; }       
    protected override void OnModelCreating(ModelBuilder modelBuilder){

        modelBuilder.Entity<ExampleDTO>().HasNoKey(); // cần cái này vì ExampleDTO không phải entity

        modelBuilder.Entity<UngVien>().HasData(new UngVien{
            Id = 1,
            HoTen = "Nguyễn Văn A",
            Email = "ungvien@email.com",
            MatKhau = "123456",
            DiaChi = "Hà Nội",
            SoDienThoai = "0123456789",
            NgaySinh = new DateTime(1999, 1, 1),
            TrinhDoHocVan = "Đại học FPT",
            TrinhDoChuyenMon = "CNTT",
            AnhDaiDien = "example.jpg",
            Cv = "example.jpg"
        },
        new UngVien{
            Id = 2,
            HoTen = "Nguyễn Văn B",
            Email = "ungvien2@email.com",
            MatKhau = "123456",
            DiaChi = "Hà Nội",
            SoDienThoai = "0123456789",
            NgaySinh = new DateTime(1999, 1, 1),
            TrinhDoHocVan = "Đại học FPT",
            TrinhDoChuyenMon = "CNTT",
            AnhDaiDien = "example.jpg",
            Cv = "example.jpg"
        },
        new UngVien{
            Id = 3,
            HoTen = "Nguyễn Văn C",
            Email = "ungvien3@email.com",
            MatKhau = "123456",
            DiaChi = "Hà Nội",
            SoDienThoai = "0123456789",
            NgaySinh = new DateTime(1999, 1, 1),
            TrinhDoHocVan = "Đại học FPT",
            TrinhDoChuyenMon = "CNTT",
            AnhDaiDien = "example.jpg",
            Cv = "example.jpg"
        }   
    );

        modelBuilder.Entity<NhanVien>().HasData(new NhanVien{
            Id = 1,
            TenNhanVien = "Nguyễn Văn B",
            Email = "nhanvien@email.com",
            MatKhau = "123456",
            AnhDaiDien = "example.jpg"
        });

        modelBuilder.Entity<DoanhNghiep>().HasData(new DoanhNghiep{
            Id = 1,
            TenDoanhNghiep = "Cty TNHH ABC",
            MaSoThue = "123456",
            DienThoai = "0123456789",
            Email = "doanhnghiep@email.com",
            MatKhau = "123456",
            NgayDangKy = new DateTime(2021, 1, 1)
        },
        new DoanhNghiep{
            Id = 2,
            TenDoanhNghiep = "Cty TNHH XYZ",
            MaSoThue = "123456",
            DienThoai = "0123456789",
            Email = "doanhnghiep2@email.com",
            MatKhau = "123456",
            NgayDangKy = new DateTime(2021, 1, 1)
        },
        new DoanhNghiep{
            Id = 3,
            TenDoanhNghiep = "Cty TNHH KLM",
            MaSoThue = "123456",
            DienThoai = "0123456789",
            Email = "doanhnghiep3@email.com",
            MatKhau = "123456",
            NgayDangKy = new DateTime(2021, 1, 1)
        });

        modelBuilder.Entity<HinhThucDangTuyen>().HasData(
            new HinhThucDangTuyen{
                Id = 1,
                TenHinhThuc = "Báo Giấy",
                MoTa = "Đăng tuyển qua báo giấy"
            },
            new HinhThucDangTuyen{  
                Id = 2,
                TenHinhThuc = "Website Công Ty",
                MoTa = "Đăng tuyển qua website công ty"
            },
            new HinhThucDangTuyen{
                Id = 3,
                TenHinhThuc = "Banner Quảng cáo",
                MoTa = "Đăng tuyển qua các banner quảng cáo"
            }
        );

        modelBuilder.Entity<HinhThucThanhToan>().HasData(
            new HinhThucThanhToan{
                Id = 1,
                TenHinhThuc = "Chuyển khoản",
                MoTa = "Thanh toán qua chuyển khoản"
            },
            new HinhThucThanhToan{
                Id = 2,
                TenHinhThuc = "Tiền mặt",
                MoTa = "Thanh toán bằng tiền mặt"
            }
        );

        modelBuilder.Entity<DangTuyen>().HasData(
            new DangTuyen{
                Id = 1,
                TenViTri = "Lập trình viên",
                SoLuong = 5,
                MoTa ="""
                    - Phát triển ứng dụng web với các Javascript Framework AngularJS hoặc ReactJS kết hợp với API Server.

                    - Phát triển thêm tính năng mới hoặc cải tiến tính năng sẵn có trên ứng dụng web theo yêu cầu.

                    - Tích hợp các thư viện của Third Party vào ứng dụng web.

                    - Tối ưu hiệu suất ứng dụng nhằm đảm bảo tính tương thích trên tất cả các thiết bị và trình duyệt khác nhau.
                """,
                ThoiGianDangTuyen = 30,
                TrangThai = "Đang tuyển",
                MucLuong = "10.000.000 - 15.000.000 VND",
                NgayDangKy = new DateTime(2021, 1, 1),
                NgayBatDau = new DateTime(2021, 1, 10),
                NgayKetThuc = new DateTime(2021, 1, 20),
                KhuVuc = "Hà Nội",
                ChuyenNganh = "IT",
                DoanhNghiepId = 1,
                HinhThucDangTuyenId = 1
            },
            new DangTuyen {
                Id = 2,
                TenViTri = "Kế toán",
                SoLuong = 2,
                MoTa = """
                    - Thực hiện các công việc kế toán theo quy định của pháp luật.

                    - Lập báo cáo tài chính hàng quý, hàng năm.

                    - Lập bảng cân đối kế toán, bảng cân đối kế toán.

                    - Lập báo cáo thuế hàng quý, hàng năm.

                    - Thực hiện các công việc khác theo sự phân công của cấp trên.
                """,
                ThoiGianDangTuyen = 30,
                TrangThai = "Đang tuyển",
                MucLuong = "5.000.000 - 7.000.000 VND",
                NgayDangKy = new DateTime(2021, 1, 1),
                NgayBatDau = new DateTime(2021, 1, 10),
                NgayKetThuc = new DateTime(2021, 1, 20),
                KhuVuc = "Hà Nội",
                ChuyenNganh = "Kế Toán",
                DoanhNghiepId = 2,
                HinhThucDangTuyenId = 2
            },
            new DangTuyen {
                Id = 3,
                TenViTri = "Nhân viên kinh doanh",
                SoLuong = 3,
                MoTa = """
                    - Tìm kiếm khách hàng tiềm năng.

                    - Tư vấn sản phẩm, dịch vụ cho khách hàng.

                    - Chăm sóc khách hàng hiện tại.

                    - Thực hiện các công việc khác theo sự phân công của cấp trên.
                """,
                ThoiGianDangTuyen = 30,
                TrangThai = "Đang tuyển",
                MucLuong = "5.000.000 - 7.000.000 VND",
                NgayDangKy = new DateTime(2021, 1, 1),
                NgayBatDau = new DateTime(2021, 1, 10),
                NgayKetThuc = new DateTime(2021, 1, 20),
                KhuVuc = "Hồ Chi Minh",
                ChuyenNganh = "Kinh Doanh",
                DoanhNghiepId = 3,
                HinhThucDangTuyenId = 3
            },
            new DangTuyen {
                Id = 4,
                TenViTri = "Nhân viên kinh doanh",
                SoLuong = 3,
                MoTa = """
                    - Tìm kiếm khách hàng tiềm năng.

                    - Tư vấn sản phẩm, dịch vụ cho khách hàng.

                    - Chăm sóc khách hàng hiện tại.

                    - Thực hiện các công việc khác theo sự phân công của cấp trên.
                """,
                ThoiGianDangTuyen = 30,
                TrangThai = "Đang tuyển",
                MucLuong = "Thỏa thuận",
                NgayDangKy = new DateTime(2021, 1, 1),
                NgayBatDau = new DateTime(2021, 1, 10),
                NgayKetThuc = new DateTime(2021, 1, 20),
                KhuVuc = "Hồ Chi Minh",
                ChuyenNganh = "Kinh Doanh",
                DoanhNghiepId = 3,
                HinhThucDangTuyenId = 3
            },
            new DangTuyen {
                Id = 5,
                TenViTri = "Nhân viên kinh doanh",
                SoLuong = 3,
                MoTa = """
                    - Tìm kiếm khách hàng tiềm năng.

                    - Tư vấn sản phẩm, dịch vụ cho khách hàng.

                    - Chăm sóc khách hàng hiện tại.

                    - Thực hiện các công việc khác theo sự phân công của cấp trên.
                """,
                ThoiGianDangTuyen = 30,
                TrangThai = "Đang tuyển",
                MucLuong = "Thỏa thuận",
                NgayDangKy = new DateTime(2021, 1, 1),
                NgayBatDau = new DateTime(2021, 1, 10),
                NgayKetThuc = new DateTime(2021, 1, 20),
                DoanhNghiepId = 3,
                KhuVuc = "Hồ Chi Minh",
                ChuyenNganh = "Kinh Doanh",
                HinhThucDangTuyenId = 3
            }
        );

        modelBuilder.Entity<TieuChiTuyenDung>().HasData(
            new TieuChiTuyenDung{
                Id = 1,
                TenTieuChi = "Kinh Nghiệm Làm Việc",
                MoTa = "30 Năm kinh nghiệm làm việc trong lĩnh vực lập trình",
                DangTuyenId = 1
            },
            new TieuChiTuyenDung{
                Id = 2,
                TenTieuChi = "Kỹ năng kế toán",
                MoTa = "Có kiến thức vững về kế toán",
                DangTuyenId = 2
            },
            new TieuChiTuyenDung{
                Id = 3,
                TenTieuChi = "Kỹ năng kinh doanh",
                MoTa = "Có kiến thức vững về kinh doanh",
                DangTuyenId = 3
            },
            new TieuChiTuyenDung{
                Id = 4,
                TenTieuChi = "Kỹ năng kinh doanh",
                MoTa = "Có kiến thức vững về kinh doanh",
                DangTuyenId = 4
            },
            new TieuChiTuyenDung{
                Id = 5,
                TenTieuChi = "Kỹ năng kinh doanh",
                MoTa = "Có kiến thức vững về kinh doanh",
                DangTuyenId = 5
            },
            new TieuChiTuyenDung{
                Id = 6,
                TenTieuChi = "Độ tuổi",
                MoTa = "20-25 tuổi",
                DangTuyenId = 1
            },
            new TieuChiTuyenDung{
                Id = 7,
                TenTieuChi = "Độ tuổi",
                MoTa = "20-25 tuổi",
                DangTuyenId = 2
            },
            new TieuChiTuyenDung{
                Id = 8,
                TenTieuChi = "Độ tuổi",
                MoTa = "20-25 tuổi",
                DangTuyenId = 3
            },
            new TieuChiTuyenDung{
                Id = 9,
                TenTieuChi = "Độ tuổi",
                MoTa = "20-25 tuổi",
                DangTuyenId = 4
            },
            new TieuChiTuyenDung{
                Id = 10,
                TenTieuChi = "Độ tuổi",
                MoTa = "20-25 tuổi",
                DangTuyenId = 5
            },
            new TieuChiTuyenDung{
                Id = 11,
                TenTieuChi = "Trình độ học vấn",
                MoTa = "Đại học",
                DangTuyenId = 1
            },
            new TieuChiTuyenDung{
                Id = 12,
                TenTieuChi = "Trình độ học vấn",
                MoTa = "Đại học",
                DangTuyenId = 2
            },
            new TieuChiTuyenDung{
                Id = 13,
                TenTieuChi = "Trình độ học vấn",
                MoTa = "Đại học",
                DangTuyenId = 3
            },
            new TieuChiTuyenDung{
                Id = 14,
                TenTieuChi = "Trình độ học vấn",
                MoTa = "Đại học",
                DangTuyenId = 4
            },
            new TieuChiTuyenDung{
                Id = 15,
                TenTieuChi = "Trình độ học vấn",
                MoTa = "Đại học",
                DangTuyenId = 5
            }
        );
        
        modelBuilder.Entity<UngTuyen>().HasData(
            new UngTuyen{
                Id = 1,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 1,
                DanhGia = null,
                UngVienId = 2,
                NhanVienKiemDuyenId = 1
            },
            new UngTuyen{
                Id = 2,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 2,
                DanhGia = null,
                UngVienId = 2,
                NhanVienKiemDuyenId = 1
            },
            new UngTuyen{
                Id = 3,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 3,
                DanhGia = null,
                UngVienId = 2,
                NhanVienKiemDuyenId = 1
            },
            new UngTuyen{
                Id = 4,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 4,
                DanhGia = null,
                UngVienId = 2,
                NhanVienKiemDuyenId = 1
            },
            new UngTuyen{
                Id = 5,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 5,
                DanhGia = null,
                UngVienId = 2,
                NhanVienKiemDuyenId = 1
            },
            new UngTuyen{
                Id = 6,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 1,
                DanhGia = null,
                UngVienId = 3,
                NhanVienKiemDuyenId = 1
            },
            new UngTuyen{
                Id = 7,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 2,
                DanhGia = null,
                UngVienId = 3,
                NhanVienKiemDuyenId = 1
            },
            new UngTuyen{
                Id = 8,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 3,
                DanhGia = null,
                UngVienId = 3,
                NhanVienKiemDuyenId = 1
            },
            new UngTuyen{
                Id = 9,
                NgayUngTuyen = new DateTime(2021, 1, 1),
                DangTuyenId = 4,
                DanhGia = null,
                UngVienId = 3,
                NhanVienKiemDuyenId = 1
            }
        );

        modelBuilder.Entity<HoSoUngTuyen>().HasData(
            new HoSoUngTuyen{
                Id = 1,
                UngTuyenId = 1,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            },
            new HoSoUngTuyen{
                Id = 2,
                UngTuyenId = 2,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            },
            new HoSoUngTuyen{
                Id = 3,
                UngTuyenId = 3,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            },
            new HoSoUngTuyen{
                Id = 4,
                UngTuyenId = 4,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            },
            new HoSoUngTuyen{
                Id = 5,
                UngTuyenId = 5,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            },
            new HoSoUngTuyen{
                Id = 6,
                UngTuyenId = 6,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            },
            new HoSoUngTuyen{
                Id = 7,
                UngTuyenId = 7,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            },
            new HoSoUngTuyen{
                Id = 8,
                UngTuyenId = 8,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            },
            new HoSoUngTuyen{
                Id = 9,
                UngTuyenId = 9,
                TenHoSo = "CV",
                MoTa = "CV",
                FileHoSo = "example.pdf"
            }
        );

    }

    
}
