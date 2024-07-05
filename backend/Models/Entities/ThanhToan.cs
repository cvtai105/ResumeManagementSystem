using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Models.Entities
{
    public class ThanhToan
    {
        public int Id { get; set; }
        public int SoTien { get; set; }
        public bool DaThanhToan { get; set; } = false;
        public DateTime? HanThanhToan { get; set; }
        // [JsonIgnore]
        public int DangTuyenId { get; set; }
        public int? HinhThucThanhToanId { get; set; } //có ai dùng cái này k. anh xóa nha. Thanh toán có 1 hoặc nhiều đợt thanh toán. hình thức thanh toán là khóa ngoại của đợt thanh t
        public List<DotThanhToan>? DotThanhToans { get; set; }
        // [JsonIgnore]
        public DangTuyen? DangTuyen { get; set; } 
        
    }
}