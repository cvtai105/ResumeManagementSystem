using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DAOs;

public class NhanVienDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<NhanVien?> GetByEmail(string email)
    {
        return await _context.NhanViens.FirstOrDefaultAsync(nv => nv.Email == email);
    }

    public async Task<NhanVien> Add(NhanVien nhanVien)
    {
        _context.NhanViens.Add(nhanVien);
        await _context.SaveChangesAsync();
        return nhanVien;
    }
}