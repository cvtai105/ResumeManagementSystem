using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;

namespace DataAccess.DAOs
{
    public class TestDAO (AppDbContext context)
    {
        private readonly AppDbContext _context = context;
        
        public async Task<ExampleDTO?> GetNhanVienInfo(string email)
        {
            //TODO: handle SQL injection
            var nhanViens = await _context.ExampleDTOs.FromSqlRaw($"EXECUTE GetNhanVienInfo '{email}'", email).ToListAsync();
            //fromesqlRaw cần thực hiện cầu lệnh toListAsync() để trả về kết quả dạng bảng/List
            var result = nhanViens.FirstOrDefault();
            return result;
        }
    }
}