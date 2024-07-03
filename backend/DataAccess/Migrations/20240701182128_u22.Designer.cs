﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240701182128_u22")]
    partial class u22
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.DTOs.ExampleDTO", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ExampleDTOs");
                });

            modelBuilder.Entity("Models.Entities.DangTuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoanhNghiepId")
                        .HasColumnType("int");

                    b.Property<int?>("HinhThucDangTuyenId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NhanVienKiemDuyetId")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenViTri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThoiGianDangTuyen")
                        .HasColumnType("int");

                    b.Property<int?>("UuDaiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoanhNghiepId");

                    b.HasIndex("HinhThucDangTuyenId");

                    b.HasIndex("NhanVienKiemDuyetId");

                    b.HasIndex("UuDaiId");

                    b.ToTable("DangTuyens");
                });

            modelBuilder.Entity("Models.Entities.DoanhNghiep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaSoThue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NhanVien")
                        .HasColumnType("int");

                    b.Property<int?>("NhanVienDangKyId")
                        .HasColumnType("int");

                    b.Property<string>("TenDoanhNghiep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NhanVien");

                    b.ToTable("DoanhNghieps");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DienThoai = "0123456789",
                            Email = "doanhnghiep@email.com",
                            MaSoThue = "123456",
                            MatKhau = "123456",
                            NgayDangKy = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenDoanhNghiep = "Cty TNHH ABC"
                        });
                });

            modelBuilder.Entity("Models.Entities.DotThanhToan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HinhThucThanhToanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NhanVienThanhToanId")
                        .HasColumnType("int");

                    b.Property<int>("SoTien")
                        .HasColumnType("int");

                    b.Property<int>("ThanhToanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HinhThucThanhToanId");

                    b.HasIndex("NhanVienThanhToanId");

                    b.HasIndex("ThanhToanId");

                    b.ToTable("DotThanhToans");
                });

            modelBuilder.Entity("Models.Entities.HinhThucDangTuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HinhThucDangTuyens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MoTa = "Đăng tuyển qua báo giấy",
                            TenHinhThuc = "Báo Giấy"
                        },
                        new
                        {
                            Id = 2,
                            MoTa = "Đăng tuyển qua website công ty",
                            TenHinhThuc = "Website Công Ty"
                        },
                        new
                        {
                            Id = 3,
                            MoTa = "Đăng tuyển qua các banner quảng cáo",
                            TenHinhThuc = "Banner Quảng cáo"
                        });
                });

            modelBuilder.Entity("Models.Entities.HinhThucThanhToan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HinhThucThanhToans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MoTa = "Thanh toán qua chuyển khoản",
                            TenHinhThuc = "Chuyển khoản"
                        },
                        new
                        {
                            Id = 2,
                            MoTa = "Thanh toán bằng tiền mặt",
                            TenHinhThuc = "Tiền mặt"
                        });
                });

            modelBuilder.Entity("Models.Entities.HoSoUngTuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileHoSo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHoSo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UngTuyenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UngTuyenId");

                    b.ToTable("HoSoUngTuyens");
                });

            modelBuilder.Entity("Models.Entities.NhanVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NhanViens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnhDaiDien = "example.jpg",
                            Email = "nhanvien@email.com",
                            MatKhau = "123456",
                            TenNhanVien = "Nguyễn Văn B"
                        });
                });

            modelBuilder.Entity("Models.Entities.ThanhToan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("DaThanhToan")
                        .HasColumnType("bit");

                    b.Property<int>("DangTuyenId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("HanThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HinhThucThanhToanId")
                        .HasColumnType("int");

                    b.Property<int>("SoTien")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DangTuyenId");

                    b.HasIndex("HinhThucThanhToanId");

                    b.ToTable("ThanhToans");
                });

            modelBuilder.Entity("Models.Entities.TieuChiTuyenDung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DangTuyenId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DangTuyenId");

                    b.ToTable("TieuChiTuyenDungs");
                });

            modelBuilder.Entity("Models.Entities.UngTuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DangTuyenId")
                        .HasColumnType("int");

                    b.Property<string>("DanhGia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayUngTuyen")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NhanVienKiemDuyenId")
                        .HasColumnType("int");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UngVienId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DangTuyenId");

                    b.HasIndex("NhanVienKiemDuyenId");

                    b.HasIndex("UngVienId");

                    b.ToTable("UngTuyens");
                });

            modelBuilder.Entity("Models.Entities.UngVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCCD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrinhDoChuyenMon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrinhDoHocVan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UngViens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnhDaiDien = "example.jpg",
                            Cv = "example.jpg",
                            DiaChi = "Hà Nội",
                            Email = "ungvien@email.com",
                            HoTen = "Nguyễn Văn A",
                            MatKhau = "123456",
                            NgaySinh = new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SoDienThoai = "0123456789",
                            TrinhDoChuyenMon = "CNTT",
                            TrinhDoHocVan = "Đại học FPT"
                        });
                });

            modelBuilder.Entity("Models.Entities.UuDai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoanhNghiepId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoanhNghiepId");

                    b.ToTable("UuDais");
                });

            modelBuilder.Entity("Models.Entities.DangTuyen", b =>
                {
                    b.HasOne("Models.Entities.DoanhNghiep", "DoanhNghiep")
                        .WithMany("DangTuyens")
                        .HasForeignKey("DoanhNghiepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.HinhThucDangTuyen", "HinhThucDangTuyen")
                        .WithMany("DangTuyens")
                        .HasForeignKey("HinhThucDangTuyenId");

                    b.HasOne("Models.Entities.NhanVien", "NhanVienKiemDuyet")
                        .WithMany()
                        .HasForeignKey("NhanVienKiemDuyetId");

                    b.HasOne("Models.Entities.UuDai", "UuDai")
                        .WithMany("DangTuyens")
                        .HasForeignKey("UuDaiId");

                    b.Navigation("DoanhNghiep");

                    b.Navigation("HinhThucDangTuyen");

                    b.Navigation("NhanVienKiemDuyet");

                    b.Navigation("UuDai");
                });

            modelBuilder.Entity("Models.Entities.DoanhNghiep", b =>
                {
                    b.HasOne("Models.Entities.NhanVien", "NhanVienDangKy")
                        .WithMany()
                        .HasForeignKey("NhanVien");

                    b.Navigation("NhanVienDangKy");
                });

            modelBuilder.Entity("Models.Entities.DotThanhToan", b =>
                {
                    b.HasOne("Models.Entities.HinhThucThanhToan", "HinhThucThanhToan")
                        .WithMany()
                        .HasForeignKey("HinhThucThanhToanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.NhanVien", "NhanVienThanhToan")
                        .WithMany()
                        .HasForeignKey("NhanVienThanhToanId");

                    b.HasOne("Models.Entities.ThanhToan", "ThanhToan")
                        .WithMany("DotThanhToans")
                        .HasForeignKey("ThanhToanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HinhThucThanhToan");

                    b.Navigation("NhanVienThanhToan");

                    b.Navigation("ThanhToan");
                });

            modelBuilder.Entity("Models.Entities.HoSoUngTuyen", b =>
                {
                    b.HasOne("Models.Entities.UngTuyen", "UngTuyen")
                        .WithMany("HoSoUngTuyens")
                        .HasForeignKey("UngTuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UngTuyen");
                });

            modelBuilder.Entity("Models.Entities.ThanhToan", b =>
                {
                    b.HasOne("Models.Entities.DangTuyen", "DangTuyen")
                        .WithMany()
                        .HasForeignKey("DangTuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.HinhThucThanhToan", null)
                        .WithMany("ThanhToans")
                        .HasForeignKey("HinhThucThanhToanId");

                    b.Navigation("DangTuyen");
                });

            modelBuilder.Entity("Models.Entities.TieuChiTuyenDung", b =>
                {
                    b.HasOne("Models.Entities.DangTuyen", "DangTuyen")
                        .WithMany("TieuChiTuyenDungs")
                        .HasForeignKey("DangTuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DangTuyen");
                });

            modelBuilder.Entity("Models.Entities.UngTuyen", b =>
                {
                    b.HasOne("Models.Entities.DangTuyen", "DangTuyen")
                        .WithMany("UngTuyens")
                        .HasForeignKey("DangTuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.NhanVien", "NhanVienKiemDuyen")
                        .WithMany()
                        .HasForeignKey("NhanVienKiemDuyenId");

                    b.HasOne("Models.Entities.UngVien", null)
                        .WithMany("UngTuyens")
                        .HasForeignKey("UngVienId");

                    b.Navigation("DangTuyen");

                    b.Navigation("NhanVienKiemDuyen");
                });

            modelBuilder.Entity("Models.Entities.UuDai", b =>
                {
                    b.HasOne("Models.Entities.DoanhNghiep", "DoanhNghiep")
                        .WithMany()
                        .HasForeignKey("DoanhNghiepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoanhNghiep");
                });

            modelBuilder.Entity("Models.Entities.DangTuyen", b =>
                {
                    b.Navigation("TieuChiTuyenDungs");

                    b.Navigation("UngTuyens");
                });

            modelBuilder.Entity("Models.Entities.DoanhNghiep", b =>
                {
                    b.Navigation("DangTuyens");
                });

            modelBuilder.Entity("Models.Entities.HinhThucDangTuyen", b =>
                {
                    b.Navigation("DangTuyens");
                });

            modelBuilder.Entity("Models.Entities.HinhThucThanhToan", b =>
                {
                    b.Navigation("ThanhToans");
                });

            modelBuilder.Entity("Models.Entities.ThanhToan", b =>
                {
                    b.Navigation("DotThanhToans");
                });

            modelBuilder.Entity("Models.Entities.UngTuyen", b =>
                {
                    b.Navigation("HoSoUngTuyens");
                });

            modelBuilder.Entity("Models.Entities.UngVien", b =>
                {
                    b.Navigation("UngTuyens");
                });

            modelBuilder.Entity("Models.Entities.UuDai", b =>
                {
                    b.Navigation("DangTuyens");
                });
#pragma warning restore 612, 618
        }
    }
}
