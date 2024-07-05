using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/hosoungtuyen")]
    public class HoSoUngTuyenController : ControllerBase
    {
        private readonly HoSoUngTuyenBL _hoSoUngTuyenBL;

        public HoSoUngTuyenController(HoSoUngTuyenBL hoSoUngTuyenBL) // Sửa tên lớp tại đây
        {
            _hoSoUngTuyenBL = hoSoUngTuyenBL;
        }

        [HttpGet("danhsach/{id}")]
        public async Task<ActionResult<IEnumerable<HoSoUngTuyen>>> GetDoanhSachHSUTByIdUngTuyen(int id)
        {
            var hosoungtuyen = await _hoSoUngTuyenBL.GetDoanhSachHSUTByIdUngTuyen(id);
            if (hosoungtuyen == null)
            {
                return NotFound();
            }
            return Ok(hosoungtuyen);
        }

        
    }
}
