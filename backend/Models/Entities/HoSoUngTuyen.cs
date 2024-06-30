namespace Models.Entities;


public class HoSoUngTuyen
{
    public int Id { get; set; }
    
    public int UngTuyenId { get; set; }
    public string? TenHoSo   { get; set; } = String.Empty;
    public string? MoTa   { get; set; } = String.Empty;
    public string? FileHoSo   { get; set; } = String.Empty;
    public UngTuyen UngTuyen { get; set; } = new();
    
}