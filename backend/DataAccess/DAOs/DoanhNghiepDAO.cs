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

        public async Task<DoanhNghiep?> GetByEmail(string email)
        {
            return await _context.DoanhNghieps.FirstOrDefaultAsync(dn => dn.Email == email);
        }

        public async Task<DoanhNghiep> Add(DoanhNghiep doanhNghiep)
        {
            _context.DoanhNghieps.Add(doanhNghiep);
            await _context.SaveChangesAsync();
            return doanhNghiep;
        }
    }
}