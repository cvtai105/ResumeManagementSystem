using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.DTOs;
using Application.Request;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/ungtuyen")]
    public class UngTuyenController : ControllerBase
    {
        private readonly UngTuyenBL _ungTuyenBL;
        private readonly ILogger<UngTuyenController> _logger;
        public UngTuyenController(UngTuyenBL ungTuyenBL, ILogger<UngTuyenController> logger)
        {
            _ungTuyenBL = ungTuyenBL;
            _logger = logger;
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
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusDto updateStatusDto)
        {
            var result = await _ungTuyenBL.UpdateStatus(id, updateStatusDto.Status);
            if (!result)
            {
                return BadRequest("Failed to update status");
            }
            return Ok("Status updated successfully");
        }

        [HttpPost("create")]
        public async Task<IActionResult> PostUngTuyen([FromForm] UngTuyenRequest data)
        {
            _logger.LogError($"Ung tuyen request received, {data.Email}, {data.Name}, {data.Phone}, {data.DangTuyenId}, {data.Cv != null}");
            if (data.Cv == null || data.Cv.Length == 0)
            {
                _logger.LogError("File not selected");
                return BadRequest("File not selected");
            }

            var newFileName = Guid.NewGuid().ToString() + data.Cv.FileName;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles/pdfs/CVs", newFileName);

            var ungtuyen = await _ungTuyenBL.UngTuyen(data.Email, data.Name, data.Phone, data.DangTuyenId, newFileName);
            if (ungtuyen == null)
            {
                return BadRequest(new { message = "Ung tuyen existed" });
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await data.Cv.CopyToAsync(stream);
            }

            return Ok(ungtuyen);
        }
    }
}
