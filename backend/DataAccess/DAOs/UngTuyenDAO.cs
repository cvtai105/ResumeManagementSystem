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
    
}