using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.DAOs
{
    public class DoanhNghiepDAO(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<List<DoanhNghiep>> GetUnverifiedDoanhNghiep()
        {
            return await _context.DoanhNghieps
                                 .Where(d => d.XacNhan == null)
                                 .ToListAsync();
        }

        public async Task<DoanhNghiep?> GetByEmail(string email)
        {
            return await _context.DoanhNghieps.FirstOrDefaultAsync(dn => dn.Email == email);
        }
        public async Task<DoanhNghiep?> GetById(int id)
        {
            return await _context.DoanhNghieps.FirstOrDefaultAsync(dn => dn.Id == id);
        }

        public async Task<DoanhNghiep> Add(DoanhNghiep doanhNghiep)
        {
            _context.DoanhNghieps.Add(doanhNghiep);
            await _context.SaveChangesAsync();
            return doanhNghiep;
        }

        public async Task<DoanhNghiep> UpdateXacNhanAsync(int id, bool xacNhan)
        {
            var doanhNghiep = await _context.DoanhNghieps.FirstOrDefaultAsync(x => x.Id == id);
            if (doanhNghiep == null) throw new KeyNotFoundException("DoanhNghiep not found");

            doanhNghiep.XacNhan = xacNhan;
            // Update Id NhanVien here if necessary
            await _context.SaveChangesAsync();
            return doanhNghiep;
        }
    }
}