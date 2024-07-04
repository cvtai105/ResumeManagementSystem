using System.Text.Json.Serialization;

namespace Models.Entities
{
    public class UuDai
    {
        public int Id { get; set; }
        public string MoTa { get; set; }= String.Empty;
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int DoanhNghiepId { get; set; }
        public DoanhNghiep DoanhNghiep { get; set; } = new();

        [JsonIgnore]
        public List<DangTuyen> DangTuyens { get; set; } = [];

    } 
}