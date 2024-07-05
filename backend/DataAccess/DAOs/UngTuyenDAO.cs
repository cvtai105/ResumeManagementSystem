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
}