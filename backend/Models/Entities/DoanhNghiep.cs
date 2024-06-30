using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class DoanhNghiep
    {
        public int Id { get; set; }
        public string TenDoanhNghiep { get; set; } = String.Empty;
        public string MaSoThue { get; set; } = String.Empty;
        public string? DienThoai { get; set; }
        public int? NhanVienDangKyId { get; set; }

        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        public string MatKhau { get; set; } = String.Empty;

        [ForeignKey("NhanVien")]
        public NhanVien? NhanVienDangKy { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public List<DangTuyen> DangTuyens { get; set; } = [];

    }
}