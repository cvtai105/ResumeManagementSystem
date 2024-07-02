using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DAOs;
using Models.DTOs;

namespace BusinessLogic
{
    public class TestBL(TestDAO testDAO)
    {
         private readonly TestDAO _testDAO = testDAO;
        public async Task<ExampleDTO?> GetNhanVienInfo(string email)
        {
            return await _testDAO.GetNhanVienInfo(email);
        }
    }
}