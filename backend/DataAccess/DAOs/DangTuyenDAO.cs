using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DAOs;

public class DangTuyenDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<DangTuyen> Add(DangTuyen dangTuyen)
    {
        _context.DangTuyens.Add(dangTuyen);
        await _context.SaveChangesAsync();
        return dangTuyen;
    }
}