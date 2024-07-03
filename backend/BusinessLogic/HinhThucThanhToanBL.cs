using DataAccess.DAOs;
using Models.Entities;
using Models.RequestRecords;

namespace BusinessLogic
{
    public class HinhThucThanhToanBL
    {
        private readonly HinhThucThanhToanDAO _hinhThucThanhToanDAO;

        public HinhThucThanhToanBL(HinhThucThanhToanDAO hinhThucThanhToanDAO)
        {
            _hinhThucThanhToanDAO = hinhThucThanhToanDAO;
        }

        public async Task<HinhThucThanhToan?> GetHinhThucThanhToanByName(string name)
        {
            return await _hinhThucThanhToanDAO.GetByName(name);
        }

        public async Task<List<HinhThucThanhToan>> GetAllHinhThucThanhToans()
        {
            return await _hinhThucThanhToanDAO.GetAll();
        }
    }
}