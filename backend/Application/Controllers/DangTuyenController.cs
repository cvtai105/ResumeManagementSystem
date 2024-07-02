using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
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
                NgayBatDau = request.StartDate,
                NgayKetThuc = request.EndDate,
                HinhThucDangTuyenId = request.PostingTypeId,
                ThoiGianDangTuyen = request.PostingDuration,
                DoanhNghiepId = request.DoanhNghiepId,
                NhanVienKiemDuyetId = null,
                UuDaiId = null,
                TieuChiTuyenDungs = request.Criteria.Split('\n').Select(c => new TieuChiTuyenDung { MoTa = c }).ToList()
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
    }
    public class DangTuyenRequestModel
    {
        public string JobPosition { get; set; }
        public int NumberOfHires { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Criteria { get; set; }
        public int PostingTypeId { get; set; }
        public int PostingDuration { get; set; }
        public int DoanhNghiepId { get; set; }
        public int? NhanVienKiemDuyetId { get; set; }
        public int? UuDaiId { get; set; }
    }
}