using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class TieuChiTuyenDung
    {
        public int Id { get; set; }
        public string? TenTieuChi { get; set; } = String.Empty;
        public string? MoTa { get; set; } = String.Empty;
        public int DangTuyenId { get; set; }
        public DangTuyen DangTuyen { get; set; } = new();
    }
}