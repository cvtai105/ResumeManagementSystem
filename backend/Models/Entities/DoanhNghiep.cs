using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models.Entities
{
    public class DoanhNghiep
    {
        public int Id { get; set; }
        public string TenDoanhNghiep { get; set; } = String.Empty;
        public string MaSoThue { get; set; } = String.Empty;
        public string? DienThoai { get; set; }
        public int? NhanVienDangKyId { get; set; }
        public bool? XacNhan { get; set; }
        public string? DiaChi {get; set; }
        public string? Image { get; set; }

        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        public string MatKhau { get; set; } = String.Empty;
        public NhanVien? NhanVienDangKy { get; set; }
        public DateTime? NgayDangKy { get; set; }
        // [JsonIgnore]
        public List<DangTuyen>? DangTuyens { get; set; }
    }
}