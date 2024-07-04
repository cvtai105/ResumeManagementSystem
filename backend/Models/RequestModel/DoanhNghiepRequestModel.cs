namespace Models.RequestModel
{
    public class DoanhNghiepRequestModel
    {
        public int Id { get; set; }
        public string TenDoanhNghiep { get; set; }
        public string MaSoThue { get; set; }
        public string DienThoai { get; set; }
        public int NhanVienDangKyId { get; set; }
        public bool XacNhan { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
    }
}