namespace Models.RequestModel
{
    public class DoanhNghiepRequestModel
    {
        public string TenDoanhNghiep { get; set; } = String.Empty;
        public string MaSoThue { get; set; }= String.Empty;
        public string NguoiDaiDien { get; set; }= String.Empty;
        public string DienThoai { get; set; }= String.Empty;
        public string DiaChi { get; set;}= String.Empty;
        public int NhanVienDangKyId { get; set; }
        public bool XacNhan { get; set; }
        public string Email { get; set; }= String.Empty;
        public string MatKhau { get; set; }= String.Empty;
    }
}