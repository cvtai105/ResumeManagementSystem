using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models.Entities
{
    public class DangTuyen
    {
        public  int Id { get; set; }
        public string? TenViTri { get; set; }
        public int? SoLuong { get; set; }
        public string? MoTa { get; set; }
        public int? ThoiGianDangTuyen { get; set; }
        public string? TrangThai { get; set; }
        public string? MucLuong { get; set; }

        //ngày bắt đầu đăng tuyển là ngày public 10 ngày sau khi thanh toán, ngày đăng ký là ngày đăng ký
        public DateTime? NgayDangKy { get; set; }
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
        // [JsonIgnore]
        public List<TieuChiTuyenDung>? TieuChiTuyenDungs { get; set; }
        [NotMapped]
        public int SoLuongUngVien { get; set; } = 0;
        // [JsonIgnore]
        public List<UngTuyen>? UngTuyens { get; set; }
        public List<ThanhToan>? ThanhToans {get; set;}
    }
}