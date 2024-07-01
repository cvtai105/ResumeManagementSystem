using DataAccess.DAOs;
using Models.Entities;
using Models.RequestRecords;

namespace BusinessLogic
{
    public class DangTuyenBL(DangTuyenDAO dangTuyenDAO)
    {
        private readonly DangTuyenDAO _dangTuyenDAO = dangTuyenDAO;

        public async Task<DangTuyen> RegisterRecruitment(DangTuyen dangTuyen)
        {
            return await _dangTuyenDAO.Add(dangTuyen);
        }
    }
}