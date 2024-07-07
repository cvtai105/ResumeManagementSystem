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

        [HttpGet("for-company/{id}")]
        public async  Task<IActionResult> DoanhNghiepGetRecruitments(int id)
        {
            var result = await  _dangtuyenBL.ListRecruitmentForCompany(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecruitmentById(int id)
        {
            _logger.LogError("Get recruitment by id");
            var recruitment = await _dangtuyenBL.GetDangTuyenById(id);
            return Ok(recruitment); //jsonserialize
        }

        [HttpGet]
        public IActionResult GetRecruitments(string? keyword = null, int page = 1, string? location = null, string? branch = null)
        {
            return Ok(_dangtuyenBL.GetRecruitments(keyword, page, location, branch));  
        }
        
    }
}