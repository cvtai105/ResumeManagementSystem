using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers{
    [Route("api/hinhthucdangtuyen")]
    [ApiController]
   public class HinhThucDangTuyenController : ControllerBase
    {
        private readonly HinhThucDangTuyenBL _hinhThucDangTuyenBL;

        public HinhThucDangTuyenController(HinhThucDangTuyenBL hinhThucDangTuyenBL)
        {
            _hinhThucDangTuyenBL = hinhThucDangTuyenBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HinhThucDangTuyen>>> GetAll()
        {
            var forms = await _hinhThucDangTuyenBL.GetAllHinhThucDangTuyens();
            return Ok(forms);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<HinhThucDangTuyen>> GetByName(string name)
        {
            var hinhThucDangTuyen = await _hinhThucDangTuyenBL.GetHinhThucDangTuyenByName(name);
            if (hinhThucDangTuyen == null)
            {
                return NotFound();
            }
            return Ok(hinhThucDangTuyen);
        }
    }
}