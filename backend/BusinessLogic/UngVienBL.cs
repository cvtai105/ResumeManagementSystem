using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DAOs;
using Models.Entities;
using Models.RequestRecords;

namespace BusinessLogic
{
    public class UngVienBL (UngVienDAO ungVienDAO)
    {
        private readonly UngVienDAO _ungVienDAO = ungVienDAO;

        public async Task<UngVien?> IsValidUser (LoginRecord loginRecord)
        {
            var ungVien = await _ungVienDAO.GetByEmail(loginRecord.Email);
            if( ungVien != null && ungVien.MatKhau == loginRecord.Password)
            {
                return ungVien;
            }
            return null;
        }

        public async Task<UngVien?> RegisterUser(UngVien? ungVien)
        {
            if (ungVien == null)
            {
                return null;
            }
            return await _ungVienDAO.Add(ungVien);
        }

        public async Task<UngVien?> GetUngVien(int id)
        {
            return await _ungVienDAO.GetById(id);
        }
      
        
    }
}