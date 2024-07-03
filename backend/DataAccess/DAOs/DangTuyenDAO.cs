using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DAOs;

public class DangTuyenDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<DangTuyen?> GetById(int id)
    {
        return await _context.DangTuyens
            .Include(d => d.TieuChiTuyenDungs)
            .Include(d => d.DoanhNghiep)
            .Include(d => d.HinhThucDangTuyen)
            .FirstOrDefaultAsync(d => d.Id == id);
    }
    public void Attach(DoanhNghiep doanhNghiep)
    {
        _context.DoanhNghieps.Attach(doanhNghiep);
    }

    public void Attach(HinhThucDangTuyen hinhThucDangTuyen)
    {
        _context.HinhThucDangTuyens.Attach(hinhThucDangTuyen);
    }

    public void Attach(NhanVien nhanVien)
    {
        _context.NhanViens.Attach(nhanVien);
    }

    public void Attach(UuDai uuDai)
    {
        _context.UuDais.Attach(uuDai);
    }

    

    public async Task<DangTuyen> Add(DangTuyen dangTuyen)
    {
        _context.Entry(dangTuyen.DoanhNghiep).State = EntityState.Unchanged;
        _context.Entry(dangTuyen.HinhThucDangTuyen).State = EntityState.Unchanged;
        

        dangTuyen.NhanVienKiemDuyet = null;
        dangTuyen.UuDai= null;
        _context.DangTuyens.Add(dangTuyen);
        await _context.SaveChangesAsync();
        return dangTuyen;
    }
}