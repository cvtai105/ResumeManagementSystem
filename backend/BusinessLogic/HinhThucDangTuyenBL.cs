using DataAccess.DAOs;
using Models.Entities;
using Models.RequestRecords;

namespace BusinessLogic
{
    public class HinhThucDangTuyenBL
    {
        private readonly HinhThucDangTuyenDAO _hinhThucDangTuyenDAO;

        public HinhThucDangTuyenBL(HinhThucDangTuyenDAO hinhThucDangTuyenDAO)
        {
            _hinhThucDangTuyenDAO = hinhThucDangTuyenDAO;
        }

        public async Task<HinhThucDangTuyen?> GetHinhThucDangTuyenByName(string name)
        {
            return await _hinhThucDangTuyenDAO.GetByName(name);
        }

        public async Task<List<HinhThucDangTuyen>> GetAllHinhThucDangTuyens()
        {
            return await _hinhThucDangTuyenDAO.GetAll();
        }
    }
}