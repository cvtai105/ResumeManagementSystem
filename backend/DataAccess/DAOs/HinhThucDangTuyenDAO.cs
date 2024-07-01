using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DAOs;

public class HinhThucDangTuyenDAO
{
    private readonly AppDbContext _context;

    public HinhThucDangTuyenDAO(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HinhThucDangTuyen?> GetByName(string name)
    {
        return await _context.HinhThucDangTuyens.FirstOrDefaultAsync(htdt => htdt.TenHinhThuc == name);
    }

    public async Task<HinhThucDangTuyen> Add(HinhThucDangTuyen hinhThucDangTuyen)
    {
        _context.HinhThucDangTuyens.Add(hinhThucDangTuyen);
        await _context.SaveChangesAsync();
        return hinhThucDangTuyen;
    }

    public async Task<List<HinhThucDangTuyen>> GetAll()
    {
        return await _context.HinhThucDangTuyens.ToListAsync();
    }
}