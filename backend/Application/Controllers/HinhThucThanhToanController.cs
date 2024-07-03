using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers{
    [Route("api/hinhthucthanhtoan")]
    [ApiController]
   public class HinhThucThanhToanController : ControllerBase
    {
        private readonly HinhThucThanhToanBL _hinhThucThanhToanBL;

        public HinhThucThanhToanController(HinhThucThanhToanBL hinhThucThanhToanBL)
        {
            _hinhThucThanhToanBL = hinhThucThanhToanBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HinhThucThanhToan>>> GetAll()
        {
            var forms = await _hinhThucThanhToanBL.GetAllHinhThucThanhToans();
            return Ok(forms);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<HinhThucThanhToan>> GetByName(string name)
        {
            var hinhThucThanhToan = await _hinhThucThanhToanBL.GetHinhThucThanhToanByName(name);
            if (hinhThucThanhToan == null)
            {
                return NotFound();
            }
            return Ok(hinhThucThanhToan);
        }
    }
}