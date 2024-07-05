using DataAccess.DAOs;
using Models.Entities;
using Models.RequestModel;
using DataAccess.Data;

namespace BusinessLogic
{
    public class TieuChiTuyenDungBL
    {
        private readonly TieuChiTuyenDungDAO _tieuChiTuyenDungDAO;
        public TieuChiTuyenDungBL(TieuChiTuyenDungDAO tieuChiTuyenDungDAO)
        {
            _tieuChiTuyenDungDAO = tieuChiTuyenDungDAO;
        }

        public async Task<IEnumerable<TieuChiTuyenDung>> GetDoanhSachTCTDByIdBaiDang(int id)
        {
            return await _tieuChiTuyenDungDAO.GetDoanhSachTCTDByIdBaiDang(id);
        }
    }
}