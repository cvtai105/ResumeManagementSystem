using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.RequestModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers{
    [Route("api/dangkydangtuyen")]
    [ApiController]
    public class DangTuyenController : ControllerBase
    {
        private readonly DangTuyenBL _dangTuyenBL;

        public DangTuyenController(DangTuyenBL dangTuyenBL)
        {
            _dangTuyenBL = dangTuyenBL;
        }

        [HttpPost]
         public async Task<ActionResult<DangTuyen>> AddDangTuyen(DangTuyenRequestModel request)
        {
            var dangTuyen = new DangTuyen
            {
                TenViTri = request.JobPosition,
                SoLuong = request.NumberOfHires,
                MoTa = request.jobDescription,
                MucLuong = !request.negotiable ?  request.minSalary +  " - " + request.maxSalary + " VNĐ" : "Thỏa thuận",
                HinhThucDangTuyenId = request.PostingTypeId,
                ThoiGianDangTuyen = request.PostingDuration,
                DoanhNghiepId = request.DoanhNghiepId,
                NhanVienKiemDuyetId = null,
                UuDaiId = null,
                TieuChiTuyenDungs = request.Criteria.Split('\n').Select(c => new TieuChiTuyenDung { MoTa = c }).ToList(),
                NgayDangKy = DateTime.UtcNow,
                ThanhToans = new List<ThanhToan>
                {
                    new ThanhToan
                    {
                        SoTien = request.TotalAmount,
                        HanThanhToan = DateTime.UtcNow,
                        DaThanhToan = request.PaymentMethod == "Chuyển khoản",
                        HinhThucThanhToanId = request.PaymentMethod == "Chuyển khoản" ? 1 : 2,
                        DotThanhToans = request.PaymentType == "part" ? new List<DotThanhToan>
                        {
                            new DotThanhToan
                            {
                                SoTien = request.InstallmentAmount,
                                NgayThanhToan = DateTime.UtcNow,
                                HinhThucThanhToanId = request.PaymentMethod == "Chuyển khoản" ? 1 : 2
                            }
                        } : new List<DotThanhToan>()
                    }
                }
            };


            var addedDangTuyen = await _dangTuyenBL.AddDangTuyen(dangTuyen);
            return CreatedAtAction(nameof(GetDangTuyenById), new { id = addedDangTuyen.Id }, addedDangTuyen);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DangTuyen>> GetDangTuyenById(int id)
        {
            var dangTuyen = await _dangTuyenBL.GetDangTuyenById(id);
            if (dangTuyen == null)
            {
                return NotFound();
            }
            return Ok(dangTuyen);
        }
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<DangTuyen>>> GetFilteredDangTuyen()
        {
            var today = DateTime.Today;
            var filteredDangTuyens = await _dangTuyenBL.GetFilteredDangTuyen(today);
            return Ok(filteredDangTuyens);
        }
    }
}