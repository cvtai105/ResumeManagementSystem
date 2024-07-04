namespace Models.Entities;


public class HoSoUngTuyen
{
    public int Id { get; set; }
    
    public int UngTuyenId { get; set; }
    public string? TenHoSo   { get; set; }
    public string? MoTa   { get; set; } 
    public string? FileHoSo   { get; set; }
    public UngTuyen? UngTuyen { get; set; }
    
}