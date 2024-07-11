using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DAOs;
using Models.Entities;
using Models.RequestRecords;

namespace BusinessLogic
{
    public class DoanhNghiepBL(DoanhNghiepDAO doanhNghiepDAO)
    {
        private readonly DoanhNghiepDAO _doanhNghiepDAO = doanhNghiepDAO;

        public async Task<DoanhNghiep?> IsValidUser(LoginRecord loginRecord)
        {
            var doanhNghiep = await _doanhNghiepDAO.GetByEmail(loginRecord.Email);
            if (doanhNghiep != null && doanhNghiep.MatKhau == loginRecord.Password)
            {
                return doanhNghiep;
            }
            return null;
        }

        public async Task<DoanhNghiep?> Register(DoanhNghiep? doanhNghiep)
        {
            if (doanhNghiep == null)
            {
                return null;
            }
            return await _doanhNghiepDAO.Add(doanhNghiep);
        }

        public async Task<List<DoanhNghiep>> GetDoanhNghiep()
        {
            return await _doanhNghiepDAO.GetUnverifiedDoanhNghiep();
        }


        public async Task<DoanhNghiep?> GetDoanhNghiepByEmail(string email)
        {
            return await _doanhNghiepDAO.GetByEmail(email);
        }

        public async Task<DoanhNghiep?> GetDoanhNghiepByID(int id)
        {
            return await _doanhNghiepDAO.GetById(id);
        }

        public async Task UpdateDoanhNghiep(DoanhNghiep doanhnghiep)
        {
            if (doanhnghiep == null) throw new ArgumentNullException(nameof(doanhnghiep));

            if (doanhnghiep.XacNhan.HasValue)
            {
                // Only call the DAO method if XacNhan is not null
                await _doanhNghiepDAO.UpdateXacNhanAsync(doanhnghiep.Id, doanhnghiep.XacNhan.Value);
            }
            else
            {
                // Handle the case where XacNhan is null (e.g., throw an exception or handle it as required)
                throw new ArgumentException("XacNhan value cannot be null");
            }
        }

    }
}