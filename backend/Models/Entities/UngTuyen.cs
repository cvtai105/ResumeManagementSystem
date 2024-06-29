using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class UngTuyen
    {
        public int Id { get; set; }
        public DateTime NgayUngTuyen { get; set; } = DateTime.Now;
        public int DangTuyenId { get; set; }
        public string? TrangThai { get; set; } = String.Empty;
        public string? DanhGia { get; set; } = String.Empty;
        [ForeignKey("NhanVien")]
        public int? NhanVienKiemDuyenId { get; set; }
        public NhanVien? NhanVienKiemDuyen { get; set; } = new();
        public DangTuyen DangTuyen { get; set; } = new();
        public List<HoSoUngTuyen> HoSoUngTuyens { get; set; } = [];
    }
}