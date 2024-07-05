using System.Linq.Expressions;
using BusinessLogic;
using DataAccess.DAOs;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Application.Controllers
{
    [Route("api/recruitments")]
    public class RecruitmentsController : ControllerBase
    {
        private readonly ILogger<RecruitmentsController> _logger;
        private readonly DangTuyenBL _dangtuyenBL;

        public RecruitmentsController(ILogger<RecruitmentsController> logger, DangTuyenBL dangtuyenBL)
        {
            _logger = logger;
            _dangtuyenBL = dangtuyenBL;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecruitmentById(int id)
        {
            //lấy chi tiết thông tin đnăg tuyển để hiển thị cho ứng viên bao gồm thông tin doanh nghiệp, tiêu chí tuyển dụng, số lượng ứng viên đã ứng tuyển
            var recruitment = await _dangtuyenBL.GetDangTuyenById(id);
            return Ok(recruitment);
        }

        [HttpGet]
        public IActionResult GetRecruitments(string? keyword = null, int page = 1, string? location = null, string? branch = null)
        {
            return Ok(_dangtuyenBL.GetRecruitments(keyword, page, location, branch));  
        }
        
    }
}