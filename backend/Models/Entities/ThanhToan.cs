using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class ThanhToan
    {
        public int Id { get; set; }
        public int SoTien { get; set; }
        public bool DaThanhToan { get; set; }
        public DateTime? HanThanhToan { get; set; }
        public int DangTuyenId { get; set; }
        public List<DotThanhToan> DotThanhToans { get; set; } = new(); 
        public DangTuyen DangTuyen { get; set; } = new();
        
    }
}