using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class HinhThucThanhToan
    {
        public int Id { get; set; }
        public string TenHinhThuc { get; set; } = String.Empty;
        public string? MoTa { get; set; }        
        public List<ThanhToan>? ThanhToans { get; set; }
    }
}