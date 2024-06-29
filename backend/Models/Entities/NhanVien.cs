using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string TenNhanVien { get; set; } = String.Empty;
        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        public string MatKhau { get; set; } = String.Empty;
        public string? AnhDaiDien { get; set; } = String.Empty;
    }
}