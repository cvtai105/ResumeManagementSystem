using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class TieuChiTuyenDung
    {
        public int Id { get; set; }
        public string? TenTieuChi { get; set; }
        public string? MoTa { get; set; }
        public int DangTuyenId { get; set; }
        public DangTuyen? DangTuyen { get; set; }
    }
}