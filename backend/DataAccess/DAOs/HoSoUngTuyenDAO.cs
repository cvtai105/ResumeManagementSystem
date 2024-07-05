using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DAOs;

public class HoSoUngTuyenDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<HoSoUngTuyen>> GetDoanhSachHSUTByIdUngTuyen(int id)
    {
        return await _context.HoSoUngTuyens
            .Where(d => d.UngTuyenId == id)
            .ToListAsync();
    }
    
}