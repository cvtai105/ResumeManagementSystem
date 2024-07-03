using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class DotThanhToan
    {
        public int Id { get; set; }
        public int SoTien { get; set; }
        public DateTime NgayThanhToan { get; set; } = DateTime.Now;
        [ForeignKey("NhanVien")]
        public int? NhanVienThanhToanId { get; set; }
        public string? GhiChu { get; set; } = String.Empty;
        public NhanVien? NhanVienThanhToan { get; set; } 
        public int ThanhToanId { get; set; }
        public ThanhToan ThanhToan { get; set; } = new();
        
        public int? HinhThucThanhToanId { get; set; }
        [ForeignKey("HinhThucThanhToanId")]
        public HinhThucThanhToan HinhThucThanhToan { get; set; }
    }
}