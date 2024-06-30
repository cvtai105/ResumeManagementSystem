using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Authorize]
    [Route("api/testauth")]
    [ApiController]
    public class Test : ControllerBase
    {
        private readonly ILogger<Test> _logger;

        public Test(ILogger<Test> logger)
        {
            _logger = logger;
        }

        
        [HttpGet("nhanvien")]
        [Authorize(Roles = "nhanvien")]
        public IActionResult TestNhanVienAuth()
        {
            return Ok("nhanvien authorized");
        }

        [HttpGet("doanhnghiep")]
        [Authorize(Roles = "doanhnghiep")]
        public IActionResult TestDoanhNghiepAuth()
        {
            return Ok("doanhnghiep authorized");
        }

        [HttpGet("ungvien")]
        [Authorize(Roles = "ungvien")]
        public IActionResult TestUngVienAuth()
        {
            return Ok("ungvien authorized");
        }        

        
    }
}