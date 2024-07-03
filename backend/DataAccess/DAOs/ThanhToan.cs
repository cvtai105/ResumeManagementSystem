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
}
