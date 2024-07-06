using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DAOs;

public class UngTuyenDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Models.Entities.UngTuyen>> GetDoanhSachUngTuyenByIdBaiDang(int idBaiDang)
{
    var ungTuyenList = await _context.UngTuyens
        .Where(u => u.DangTuyenId == idBaiDang)
        .Select(u => new Models.Entities.UngTuyen
        {
            Id = u.Id,
            TrangThai = u.TrangThai ?? "Chưa xử lý",
            NhanVienKiemDuyenId = u.NhanVienKiemDuyenId,
            UngVienId = u.UngVienId,
            NgayUngTuyen = u.NgayUngTuyen
        })
        .ToListAsync();

    return ungTuyenList;
}

    public async Task<bool> UpdateStatus(int id, string status)
    {
        var ungTuyen = await _context.UngTuyens.FindAsync(id);
        if (ungTuyen == null)
        {
            return false;
        }
        ungTuyen.TrangThai = status;
        await _context.SaveChangesAsync();
        return true;
}
    public async Task<UngTuyen> Add(UngTuyen ungTuyen)
    {   
        await _context.UngTuyens.AddAsync(ungTuyen);
        await _context.SaveChangesAsync();
        return ungTuyen;
    }

    public async Task<UngTuyen> Update(UngTuyen application)
    {
        _context.UngTuyens.Attach(application);
        _context.Entry(application).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return application;
    }

    public async Task<UngTuyen?> GetByUngVienIdAndDangTuyenId(int id, int dangTuyenId)
    {
        return await _context.UngTuyens.FirstOrDefaultAsync(u => u.UngVienId == id && u.DangTuyenId == dangTuyenId);
    }
}