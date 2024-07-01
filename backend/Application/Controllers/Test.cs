using BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/testauth")]
    [ApiController]
    public class Test : ControllerBase
    {

        private readonly ILogger<Test> _logger;
        private readonly TestBL _testBL;

        public Test(ILogger<Test> logger, TestBL TestBL)
        {
            _logger = logger;
            _testBL = TestBL;
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

        [HttpGet("testprocedure")]
        public async Task<IActionResult> TestProcedure(string email)
        {
            var result = await _testBL.GetNhanVienInfo(email);
            return Ok(result);
        }
        
    }
}