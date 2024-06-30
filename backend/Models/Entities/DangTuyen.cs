using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class DangTuyen
    {
        public  int Id { get; set; }
        public string? TenViTri { get; set; } = String.Empty;
        public int? SoLuong { get; set; }
        public string? MoTa { get; set; } = String.Empty;
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int DoanhNghiepId { get; set; }
        
        [ForeignKey("NhanVien")]
        public int? NhanVienKiemDuyetId { get; set; }
        public int? UuDaiId { get; set; }
        public int? HinhThucDangTuyenId { get; set; }
        public DoanhNghiep DoanhNghiep { get; set; } = new();
        public UuDai UuDai { get; set; } = new();
        public ThanhToan ThanhToan { get; set; } = new();
        public NhanVien NhanVienKiemDuyet { get; set; } = new();
        public HinhThucDangTuyen HinhThucDangTuyen { get; set; } = new(); 
        public List<TieuChiTuyenDung> TieuChiTuyenDungs { get; set; } = [];
        public List<UngTuyen> UngTuyens { get; set; } = [];
    }
}