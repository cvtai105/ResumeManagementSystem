using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models.Entities
{
    public class DangTuyen
    {
        public  int Id { get; set; }
        public string? TenViTri { get; set; } = String.Empty;
        public int? SoLuong { get; set; }
        public string? MoTa { get; set; } = String.Empty;
        public int? ThoiGianDangTuyen { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int DoanhNghiepId { get; set; }
        public int? NhanVienKiemDuyetId { get; set; } 
        public int? UuDaiId { get; set; }
        public int? HinhThucDangTuyenId { get; set; }
        
        public DoanhNghiep DoanhNghiep { get; set; } = new();
        public UuDai? UuDai { get; set; } = new();
        public NhanVien? NhanVienKiemDuyet { get; set; } = new();
        public HinhThucDangTuyen HinhThucDangTuyen { get; set; } = new(); 
        [JsonIgnore]
        public List<TieuChiTuyenDung> TieuChiTuyenDungs { get; set; } = [];
        public List<UngTuyen> UngTuyens { get; set; } = [];
        public List<ThanhToan> ThanhToans {get; set;} = [];
    }
}