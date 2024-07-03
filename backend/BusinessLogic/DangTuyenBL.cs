using DataAccess.DAOs;
using Models.Entities;

namespace BusinessLogic
{
    public class DangTuyenBL
    {
       private readonly DangTuyenDAO _dangTuyenDAO;
        private readonly TieuChiTuyenDungDAO _tieuChiTuyenDungDAO;
        private readonly DoanhNghiepDAO _doanhNghiepDAO;
        private readonly HinhThucDangTuyenDAO _hinhThucDangTuyenDAO;
        private readonly NhanVienDAO _nhanVienDAO;
        private readonly UuDaiDAO _uuDaiDAO;

        public DangTuyenBL(DangTuyenDAO dangTuyenDAO, TieuChiTuyenDungDAO tieuChiTuyenDungDAO, DoanhNghiepDAO doanhNghiepDAO, HinhThucDangTuyenDAO hinhThucDangTuyenDAO, NhanVienDAO nhanVienDAO, UuDaiDAO uuDaiDAO)
        {
            _dangTuyenDAO = dangTuyenDAO;
            _tieuChiTuyenDungDAO = tieuChiTuyenDungDAO;
            _doanhNghiepDAO = doanhNghiepDAO;
            _hinhThucDangTuyenDAO = hinhThucDangTuyenDAO;
            _nhanVienDAO = nhanVienDAO;
            _uuDaiDAO = uuDaiDAO;
        }

        public async Task<DangTuyen> AddDangTuyen(DangTuyen dangTuyen)
        {
            var doanhNghiep = await _doanhNghiepDAO.GetById(dangTuyen.DoanhNghiepId);
            if (doanhNghiep == null)
            {
                throw new ArgumentException("Doanh nghiệp không tồn tại.");
            }
            dangTuyen.DoanhNghiep = doanhNghiep;

            // Validate and assign HinhThucDangTuyen if it is provided
            if (dangTuyen.HinhThucDangTuyenId.HasValue)
            {
                var hinhThucDangTuyen = await _hinhThucDangTuyenDAO.GetById(dangTuyen.HinhThucDangTuyenId.Value);
                if (hinhThucDangTuyen == null)
                {
                    throw new ArgumentException("Hình thức đăng tuyển không tồn tại.");
                }
                dangTuyen.HinhThucDangTuyen = hinhThucDangTuyen;
            }

            // Validate and assign NhanVienKiemDuyet if it is provided
            dangTuyen.NhanVienKiemDuyet = null;
            dangTuyen.UuDai = null;
           

            var addedDangTuyen = await _dangTuyenDAO.Add(dangTuyen);
            foreach (var criteria in dangTuyen.TieuChiTuyenDungs)
            {
                criteria.DangTuyenId = addedDangTuyen.Id;
                await _tieuChiTuyenDungDAO.Add(criteria);
            }
            return addedDangTuyen;
        }

        public async Task<DangTuyen?> GetDangTuyenById(int id)
        {
            return await _dangTuyenDAO.GetById(id);
        }



       

        public async Task<IEnumerable<DangTuyen>> GetFilteredDangTuyen(DateTime today)
        {
            return await _dangTuyenDAO.GetFilteredDangTuyen(today);
        }
    }
}