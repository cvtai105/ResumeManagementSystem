using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DAOs;

public class UngTuyenDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<UngTuyen>> GetDoanhSachUngTuyenByIdBaiDang(int idContract)
    {
        return await _context.UngTuyens
            .Where(d => d.DangTuyenId == idContract)
            .ToListAsync();
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
    
}