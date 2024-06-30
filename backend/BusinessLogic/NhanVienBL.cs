using DataAccess.DAOs;
using Models.Entities;
using Models.RequestRecords;

namespace BusinessLogic
{
    public class NhanVienBL(NhanVienDAO nhanVienDAO)
    {
        private readonly NhanVienDAO _nhanVienDAO = nhanVienDAO;

        public async Task<bool> IsValidUser(LoginRecord loginRecord)
        {   
            NhanVien? nhanVien = await _nhanVienDAO.GetByEmail(loginRecord.Email);
            return nhanVien != null && nhanVien.MatKhau == loginRecord.Password;
        }

        public async Task<NhanVien> RegisterUser(NhanVien nhanVien)
        {
            return await _nhanVienDAO.Add(nhanVien);
        }
    }
}