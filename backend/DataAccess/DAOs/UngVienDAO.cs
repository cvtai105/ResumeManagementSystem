using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DAOs
{
    public class UngVienDAO(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<UngVien?> GetByEmail(string email)
        {
            return await _context.UngViens.FirstOrDefaultAsync(uv => uv.Email == email);
        }

        public async Task<UngVien> Add(UngVien ungVien)
        {
            _context.UngViens.Add(ungVien);
            await _context.SaveChangesAsync();
            return ungVien;
        }
        
    }
}