using System.Threading.Tasks;
using DataAccess.Data;
using Models.Entities;
using Microsoft.EntityFrameworkCore;

public class ThanhToanDAO
{
    private readonly AppDbContext _context;

    public ThanhToanDAO(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ThanhToan> Add(ThanhToan thanhToan)
    {
        _context.ThanhToans.Add(thanhToan);
        await _context.SaveChangesAsync();
        return thanhToan;
    }

    public async Task<decimal> GetPaymentAmount(int id)
    {
        var thanhToan = await _context.ThanhToans.FirstOrDefaultAsync(t => t.Id == id);

        if (thanhToan == null)
        {
            throw new ArgumentException("ThanhToan not found.");
        }

        return thanhToan.SoTien;
    }

    public async Task<decimal> GetTotalPaidAmount(int id)
    {
        var thanhToan = await _context.ThanhToans
            .Include(t => t.DotThanhToans)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (thanhToan == null)
        {
            throw new ArgumentException("ThanhToan not found.");
        }

        return thanhToan.DotThanhToans.Sum(dt => dt.SoTien);
    }

    //le
    public async Task<bool> UpdatePaymentStatus(int dangTuyenId, bool status)
    {
        var thanhToanList = await _context.ThanhToans
            .Where(tt => tt.DangTuyenId == dangTuyenId)
            .ToListAsync();

        if (thanhToanList == null || !thanhToanList.Any())
        {
            return false;
        }

        foreach (var thanhToan in thanhToanList)
        {
            thanhToan.DaThanhToan = status;
        }

        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> GetPaymentStatus(int id)
    {
        var thanhToan = await _context.ThanhToans
            .FirstOrDefaultAsync(tt => tt.DangTuyenId == id);

        if (thanhToan == null)
        {
            return false;
        }

        return thanhToan.DaThanhToan;
    }

}
