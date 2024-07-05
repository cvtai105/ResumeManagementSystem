using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DAOs;

public class TieuChiTuyenDungDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<TieuChiTuyenDung?> GetById(int dangTuyenID, int tieuChiID)
    {
        return await _context.TieuChiTuyenDungs.FirstOrDefaultAsync(tieuChi => tieuChi.Id == tieuChiID && tieuChi.DangTuyenId == dangTuyenID);
    }

    public async Task<TieuChiTuyenDung> Add(TieuChiTuyenDung tieuChiTuyenDung)
    {
        _context.TieuChiTuyenDungs.Add(tieuChiTuyenDung);
        await _context.SaveChangesAsync();
        return tieuChiTuyenDung;
    }
    public async Task<IEnumerable<TieuChiTuyenDung>> GetDoanhSachTCTDByIdBaiDang(int id)
    {
        return await _context.TieuChiTuyenDungs
            .Where(d => d.DangTuyenId == id)
            .ToListAsync();
    }

}