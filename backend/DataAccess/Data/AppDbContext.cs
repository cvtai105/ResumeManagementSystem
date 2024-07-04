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
        });

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
                HinhThucDangTuyenId = 3
            }
            
        );

    }

    
}
