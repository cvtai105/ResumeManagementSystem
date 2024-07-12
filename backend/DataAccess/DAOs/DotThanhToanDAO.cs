using System.Threading.Tasks;
using DataAccess.Data;
using Models.Entities;
using Microsoft.EntityFrameworkCore;

public class DotThanhToanDAO
{
    private readonly AppDbContext _context;

    public DotThanhToanDAO(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DotThanhToan> Add(DotThanhToan dotThanhToan)
    {
        _context.Entry(dotThanhToan.ThanhToan).State = EntityState.Unchanged;
        _context.Entry(dotThanhToan.HinhThucThanhToan).State = EntityState.Unchanged;
        
        _context.DotThanhToans.Add(dotThanhToan);
        await _context.SaveChangesAsync();
        return dotThanhToan;
    }

}
