using DataAccess.DAOs;
using Models.Entities;

namespace BusinessLogic
{
    public class NhanVienBL(NhanVienDAO nhanVienDAO)
    {
        private readonly NhanVienDAO _nhanVienDAO = nhanVienDAO;

        public async Task<NhanVien> GetByEmail(string email)
        {
            return await _nhanVienDAO.GetByEmail(email);
        }
        public async Task<NhanVien> Add(NhanVien nhanVien)
        {
            return await _nhanVienDAO.Add(nhanVien);
        }
    }
}