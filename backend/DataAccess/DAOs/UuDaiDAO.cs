using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DAOs;

public class UuDaiDAO(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<UuDai?> GetById(int id)
    {
        return await _context.UuDais.FirstOrDefaultAsync(ud => ud.Id == id);
    }
}