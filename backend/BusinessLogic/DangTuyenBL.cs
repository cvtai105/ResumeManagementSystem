using System.Linq.Expressions;
using DataAccess.DAOs;
using Models.Entities;
using Models.RequestModel;

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
        private readonly DotThanhToanDAO _dotThanhToanDAO;
        private readonly ThanhToanDAO _thanhToanDAO;

        public DangTuyenBL(DangTuyenDAO dangTuyenDAO, TieuChiTuyenDungDAO tieuChiTuyenDungDAO, DoanhNghiepDAO doanhNghiepDAO, HinhThucDangTuyenDAO hinhThucDangTuyenDAO, NhanVienDAO nhanVienDAO, UuDaiDAO uuDaiDAO, DotThanhToanDAO dotThanhToanDAO, ThanhToanDAO thanhToanDAO)
        {
            _dangTuyenDAO = dangTuyenDAO;
            _tieuChiTuyenDungDAO = tieuChiTuyenDungDAO;
            _doanhNghiepDAO = doanhNghiepDAO;
            _hinhThucDangTuyenDAO = hinhThucDangTuyenDAO;
            _nhanVienDAO = nhanVienDAO;
            _uuDaiDAO = uuDaiDAO;
            _dotThanhToanDAO = dotThanhToanDAO;
            _thanhToanDAO = thanhToanDAO;
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

           foreach (var payment in dangTuyen.ThanhToans)
            {
                payment.DangTuyenId = addedDangTuyen.Id;
                var addedThanhToan = await _thanhToanDAO.Add(payment);

                foreach (var installment in payment.DotThanhToans)
                {
                    installment.ThanhToanId = addedThanhToan.Id;
                    await _dotThanhToanDAO.Add(installment);
                }
            }

            // Add TieuChiTuyenDungs
            foreach (var criteria in dangTuyen.TieuChiTuyenDungs)
            {
                criteria.DangTuyenId = addedDangTuyen.Id;
                await _tieuChiTuyenDungDAO.Add(criteria);
            }

            

            // Add Payment Information
            // var thanhToan = new ThanhToan
            // {
            //     DangTuyenId = addedDangTuyen.Id,
            //     SoTien = request.TotalAmount,
            //     HanThanhToan = DateTime.UtcNow,
            // };
            // if (request.PaymentMethod == "Chuyển khoản"){
            //     thanhToan.DaThanhToan = true;
            //     thanhToan.HinhThucThanhToanId = 1;
            // }
            // else {
            //     thanhToan.DaThanhToan = false;
            //     thanhToan.HinhThucThanhToanId = 2;
            // }
            // var addedThanhToan = await _thanhToanDAO.Add(thanhToan);

            // if (request.PaymentType == "part")
            // {
            //     var dotThanhToan = new DotThanhToan
            //     {
            //         ThanhToanId = addedThanhToan.Id,
            //         SoTien = request.InstallmentAmount,
            //         NgayThanhToan = DateTime.UtcNow,
            //     };
            //     if (request.PaymentMethod == "Chuyển khoản"){
            //         dotThanhToan.HinhThucThanhToanId = 1;
            //     }
            //     else{
            //         dotThanhToan.HinhThucThanhToanId = 2;
            //     }
            //     await _dotThanhToanDAO.Add(dotThanhToan);
            // }
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


        //Tài
        public  Object GetRecruitments(string? keyword = null, int page = 1, string? location = null, string? branch = null)
        {

            // Define the filter
            Expression<Func<DangTuyen, bool>> filter = r =>
                (string.IsNullOrEmpty(keyword) || (r.TenViTri != null && r.TenViTri.Contains(keyword)) || (r.MoTa != null && r.MoTa.Contains(keyword)))  &&
                (string.IsNullOrEmpty(location) || r.KhuVuc == location) &&
                (string.IsNullOrEmpty(branch) || r.ChuyenNganh == branch) && r.NgayKetThuc >= DateTime.Now;

            // Define the ordering (for example, by Id)
            Func<IQueryable<DangTuyen>, IOrderedQueryable<DangTuyen>> orderBy = q => q.OrderByDescending(r => r.Id);

            // Get the data from the repository
            IEnumerable<DangTuyen> recruitments = _dangTuyenDAO.Get(filter, orderBy,"DoanhNghiep");

            // Apply pagination
            int pageSize = 8;
            var pagedRecruitments = recruitments.Skip((page - 1) * pageSize).Take(pageSize);

            var info = new {
                Total = recruitments.Count(),
                PerPage = pageSize,
                PageCount = (int) Math.Ceiling((double) recruitments.Count() / pageSize),
                Data = pagedRecruitments
            };

            return info;
        }

        public async Task<DangTuyen?> GetDetailDangTuyenForDoanhNghiep(int id)
        {
            return await _dangTuyenDAO.GetDetailForDoanhNghiep(id);
        }
    }
}