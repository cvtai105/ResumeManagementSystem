using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.RequestModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/dangkydoanhnghiep")]
    [ApiController]
    public class DoanhNghiepController : ControllerBase
    {
        private readonly DoanhNghiepBL _doanhNghiepBL;

        public DoanhNghiepController(DoanhNghiepBL doanhNghiepBL)
        {
            _doanhNghiepBL = doanhNghiepBL;
        }

        [HttpPost]
        public async Task<ActionResult<DoanhNghiep>> AddDoanhNghiep(DoanhNghiepRequestModel request)
        {
            var doanhnghiep = new DoanhNghiep
            {
                TenDoanhNghiep = request.TenDoanhNghiep,
                MaSoThue = request.MaSoThue,
                DienThoai = request.DienThoai,
                DiaChi = request.DiaChi,
                NhanVienDangKyId = null,
                XacNhan = null,
                Email = request.Email,
                MatKhau = request.MatKhau
            };
            Console.WriteLine(request);
            var addDoanhNghiep = await _doanhNghiepBL.Register(doanhnghiep);
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<DoanhNghiep>> GetDoanhNghiepByEmail(String gmail)
        {
            var doanhnghiep = await _doanhNghiepBL.GetDoanhNghiepByEmail(gmail);
            if (doanhnghiep == null)
            {
                return NotFound();
            }
            return Ok(doanhnghiep);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoanhNghiep>> GetDoanhNghiepByID(int id)
        {
            var doanhnghiep = await _doanhNghiepBL.GetDoanhNghiepByID(id);
            if (doanhnghiep == null)
            {
                return NotFound();
            }
            return Ok(doanhnghiep);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateXacNhan(int id, [FromBody] bool xacNhan)
        {
            var doanhnghiep = await _doanhNghiepBL.GetDoanhNghiepByID(id);
            if (doanhnghiep == null)
            {
                return NotFound();
            }

            doanhnghiep.XacNhan = xacNhan;
            try
            {
                _doanhNghiepBL.UpdateDoanhNghiep(doanhnghiep);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return NoContent();
        }


    }
}