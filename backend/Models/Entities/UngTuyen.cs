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
        public DateTime? NgayUngTuyen { get; set; }
        public int DangTuyenId { get; set; } = 0;
        public string? TrangThai { get; set; }
        public string? DanhGia { get; set; }

        public int UngVienId{get; set;}

        public int? NhanVienKiemDuyenId { get; set; }
        public NhanVien? NhanVienKiemDuyen { get; set; }
        public DangTuyen? DangTuyen { get; set; }
        public UngVien? UngVien{get; set;}
        public List<HoSoUngTuyen>? HoSoUngTuyens { get; set; }
    }
}