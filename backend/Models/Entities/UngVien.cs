using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Models.Entities
{
    public class UngVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; } = String.Empty;
        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        public string MatKhau { get; set; } = String.Empty;
        public string? CCCD { get; set; }
        public string? SoDienThoai { get; set; } 
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? TrinhDoHocVan { get; set; } 
        public string? TrinhDoChuyenMon { get; set; } 
        public string? AnhDaiDien { get; set; } 
        public string? Cv { get; set; } 
        [JsonIgnore]
        public List<UngTuyen> UngTuyens { get; set; } = [];
    }
}