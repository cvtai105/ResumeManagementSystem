using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/tieuchituyendung")]
    public class TieuChiTuyenDungController : ControllerBase
    {
        private readonly TieuChiTuyenDungBL _tieuChiTuyenDungBL;

        public TieuChiTuyenDungController(TieuChiTuyenDungBL tieuChiTuyenDungBL)
        {
            _tieuChiTuyenDungBL = tieuChiTuyenDungBL;
        }

        [HttpGet("danhsach/{id}")]
        public async Task<ActionResult<IEnumerable<UngTuyen>>> GetDoanhSachTCTDByIdBaiDang(int id)
        {
            var tieuchituyendung = await _tieuChiTuyenDungBL.GetDoanhSachTCTDByIdBaiDang(id);
            if (tieuchituyendung == null)
            {
                return NotFound();
            }
            return Ok(tieuchituyendung);
        }
    }
}
