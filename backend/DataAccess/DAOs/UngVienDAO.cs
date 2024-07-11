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
            try{
                return await _context.UngViens.FirstOrDefaultAsync(uv => uv.Email == email);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(
                    "An error occurred while trying to get UngVien by email"
                );
                System.Console.WriteLine(e);
                return null;
            }
        }

        public async Task<UngVien> Add(UngVien ungVien)
        {
            _context.UngViens.Add(ungVien);
            await _context.SaveChangesAsync();
            return ungVien;
        }

        public async Task<UngVien?> GetById(int id)
        {
            return await _context.UngViens.FirstOrDefaultAsync(uv => uv.Id == id);
        }
    }
}