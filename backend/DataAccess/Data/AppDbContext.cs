using Microsoft.EntityFrameworkCore;
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
    protected override void OnModelCreating(ModelBuilder modelBuilder){
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
        
    }

    
}
