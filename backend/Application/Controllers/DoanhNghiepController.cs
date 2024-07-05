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
        public async Task<ActionResult> AddDoanhNghiep([FromBody] DoanhNghiepRequestModel request)
        {
            if (request == null || string.IsNullOrEmpty(request.TenDoanhNghiep) || string.IsNullOrEmpty(request.MaSoThue) ||
                string.IsNullOrEmpty(request.DienThoai) || string.IsNullOrEmpty(request.DiaChi) ||
                string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.MatKhau))
            {
                return BadRequest(new { message = "Bạn điền thiếu thông tin" });
            }

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

            try
            {
                var addDoanhNghiep = await _doanhNghiepBL.Register(doanhnghiep);

                if (addDoanhNghiep != null)
                {
                    return Ok(new { message = "Đang trong quá trình xác thực" });
                }
                else
                {
                    return StatusCode(500, new { message = "An error occurred while processing your request." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                Console.WriteLine(ex);
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
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