using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DAOs;

public class HinhThucThanhToanDAO
{
    private readonly AppDbContext _context;

    public HinhThucThanhToanDAO(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HinhThucThanhToan?> GetByName(string name)
    {
        return await _context.HinhThucThanhToans.FirstOrDefaultAsync(httt => httt.TenHinhThuc == name);
    }

    public async Task<HinhThucThanhToan?> GetById(int id)
    {
        return await _context.HinhThucThanhToans.FirstOrDefaultAsync(httt => httt.Id == id);
    }


    public async Task<List<HinhThucThanhToan>> GetAll()
    {
        return await _context.HinhThucThanhToans.ToListAsync();
    }
}