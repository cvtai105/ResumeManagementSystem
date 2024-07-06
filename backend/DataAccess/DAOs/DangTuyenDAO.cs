using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.DAOs;

public class DangTuyenDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<DangTuyen?> GetById(int id)
    {
        var dangTuyen = await _context.DangTuyens
        .Include(d => d.TieuChiTuyenDungs)
        .Include(d => d.DoanhNghiep)
        .Include(d => d.HinhThucDangTuyen)
        .Include(d => d.UngTuyens)
        .FirstOrDefaultAsync(d => d.Id == id);

        if (dangTuyen!=null && dangTuyen.UngTuyens != null)
        {
            // Tính toán số lượng ứng tuyển
            dangTuyen.SoLuongUngVien = dangTuyen.UngTuyens.Count;
        }

        return dangTuyen;
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
    public async Task<IEnumerable<DangTuyen>> GetFilteredDangTuyen(DateTime today)
    {
        var query = _context.Set<DangTuyen>()
            .Include(dt => dt.UngTuyens)
            .Include(dt => dt.DoanhNghiep);

        var result = await query.ToListAsync();

        return result.Where(dt => 
            dt.SoLuong == dt.UngTuyens.Count || dt.NgayKetThuc <= today).ToList();
    }
    public async Task<IEnumerable<Object>> GetHoSoUngTuyenThuocIDUngTuyen(int id)
    {
    using (var context = _context)
    {
        var result = await context.DangTuyens
            .Where(dt => dt.Id == id)
            .Join(context.UngTuyens,
                  dt => dt.Id,
                  ut => ut.DangTuyenId,
                  (dt, ut) => new { dt, ut })
            .Join(context.UngViens,
                  combined => combined.ut.UngVienId,
                  uv => uv.Id,
                  (combined, uv) => new { combined.dt, combined.ut, uv })
            .Join(context.HoSoUngTuyens,
                  combined => combined.ut.Id,
                  hsut => hsut.UngTuyenId,
                  (combined, hsut) => new
                  {
                      combined.ut.Id,
                      combined.uv.HoTen,
                      combined.uv.Email,
                      combined.uv.SoDienThoai,
                      combined.uv.AnhDaiDien,
                      hsut.TenHoSo,
                      hsut.FileHoSo
                  })
            .ToListAsync();

        return result;
    }
    }

    //Tài
    public IEnumerable<DangTuyen> Get(
        Expression<Func<DangTuyen, bool>>? filter = null,
        Func<IQueryable<DangTuyen>, IOrderedQueryable<DangTuyen>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<DangTuyen> query = _context.DangTuyens;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    //khi doanh nghiep xem chi tiết đăng tuyển, cần lấy ra danh sách ứng viên đã ứng tuyển và các Hồ sơ ứng tuyển 
    public async Task<DangTuyen?> GetDetailForDoanhNghiep(int idDangTuyen)
    {
        try{
            var dangTuyen = await _context.DangTuyens
            .Include(dt => dt.UngTuyens)
                .ThenInclude(dut => dut.UngVien) // Include thông tin ứng viên
            .Include(dt => dt.UngTuyens)
                .ThenInclude(dut => dut.HoSoUngTuyens)
            .FirstOrDefaultAsync(dt => dt.Id == idDangTuyen);  

            if (dangTuyen!=null && dangTuyen.UngTuyens != null)
            {
                // Tính toán số lượng ứng tuyển
                dangTuyen.SoLuongUngVien = dangTuyen.UngTuyens.Count;
            }

            return dangTuyen;
        }
        catch(Exception){
            return null;
        }

    }
}