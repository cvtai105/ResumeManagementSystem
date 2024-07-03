using DataAccess.DAOs;
using Models.Entities;

namespace BusinessLogic
{
    public class TieuChiTuyenDungBL(TieuChiTuyenDungDAO tieuChiTuyenDungDAO)
    {
        private readonly TieuChiTuyenDungDAO _tieuChiTuyenDungDAO = tieuChiTuyenDungDAO;
        
    }
}