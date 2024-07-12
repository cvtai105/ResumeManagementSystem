using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models.Entities
{
    public class DangTuyen
    {
        public int Id { get; set; }
        public string? TenViTri { get; set; }
        public int? SoLuong { get; set; }
        public string? MoTa { get; set; }
        public int? ThoiGianDangTuyen { get; set; }
        public string? TrangThai { get; set; } = "Đang chờ kiểm duyệt";
        public string? MucLuong { get; set; } = "Thỏa thuận";
        public string? ChuyenNganh { get; set; } = "Không yêu cầu";
        public string? KhuVuc { get; set; }
        public DateTime? NgayDangKy { get; set; } = DateTime.Now;
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int DoanhNghiepId { get; set; }
        public int? NhanVienKiemDuyetId { get; set; }
        public int? UuDaiId { get; set; }
        public int? HinhThucDangTuyenId { get; set; }
        public DoanhNghiep? DoanhNghiep { get; set; }
        public UuDai? UuDai { get; set; }
        public NhanVien? NhanVienKiemDuyet { get; set; }
        public HinhThucDangTuyen? HinhThucDangTuyen { get; set; }
        public List<TieuChiTuyenDung>? TieuChiTuyenDungs { get; set; }
        [NotMapped]
        public int SoLuongUngVien { get; set; } = 0;
        public List<UngTuyen>? UngTuyens { get; set; }
        public List<ThanhToan>? ThanhToans { get; set; }
    }
}
