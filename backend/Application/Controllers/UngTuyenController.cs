using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/ungtuyen")]
    public class UngTuyenController : ControllerBase
    {
        private readonly UngTuyenBL _ungTuyenBL;

        public UngTuyenController(UngTuyenBL ungTuyenBL)
        {
            _ungTuyenBL = ungTuyenBL;
        }

        [HttpGet("danhsach/{id}")]
        public async Task<ActionResult<IEnumerable<UngTuyen>>> GetDoanhSachUngTuyenByIdBaiDang(int id)
        {
            var ungtuyen = await _ungTuyenBL.GetDoanhSachUngTuyenByIdBaiDang(id);
            if (ungtuyen == null)
            {
                return NotFound();
            }
            return Ok(ungtuyen);
        }
    }
}
