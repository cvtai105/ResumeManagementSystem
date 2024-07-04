namespace Models.RequestModel
{
    public class DangTuyenRequestModel
    {
        public string JobPosition { get; set; } = String.Empty;
        public int NumberOfHires { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Criteria { get; set; }= String.Empty;
        public int PostingTypeId { get; set; }
        public int PostingDuration { get; set; }
        public int DoanhNghiepId { get; set; }
        public int? NhanVienKiemDuyetId { get; set; }
        public int? UuDaiId { get; set; }
        public int TotalAmount { get; set; }
        public int InstallmentAmount { get; set; }
        public string PaymentType { get; set; }= String.Empty;
        public string PaymentMethod { get; set; }= String.Empty;
    }
}