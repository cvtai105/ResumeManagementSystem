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

        public async Task<DoanhNghiep> UpdateXacNhan(int id, bool xacNhan)
        {
            var doanhNghiep = _context.DoanhNghieps.First(x => x.Id == id);
            doanhNghiep.XacNhan = xacNhan;
            //Cap nhat Id NhanVien o day
            await _context.SaveChangesAsync();
            return doanhNghiep;
        }

        public async Task<DoanhNghiep?> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}