using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Application.Controllers
{
    [Route("api/recruitments")]
    public class RecruitmentsController : ControllerBase
    {
        private readonly ILogger<RecruitmentsController> _logger;

        private static readonly List<DangTuyen> Recruitments = new List<DangTuyen>
        {
            new DangTuyen { Id = 1, TenViTri = "Software Developer", ChuyenNganh =  "IT", KhuVuc = "HCM"},
            new DangTuyen { Id = 2, TenViTri = "Data Analyst", ChuyenNganh ="IT", KhuVuc = "HN"},
            new DangTuyen { Id = 3, TenViTri = "HR Manager", ChuyenNganh = "HR", KhuVuc = "HCM"},
            // Add more recruitment entries here
        };

        public RecruitmentsController(ILogger<RecruitmentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("new")]
        public IActionResult GetNewRecruitments([FromQuery] int page = 1)
        {
            int pageSize = 10; // Define how many items per page
            var paginatedRecruitments = Recruitments
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(paginatedRecruitments);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecruitmentById(int id)
        {
            var recruitment = Recruitments.FirstOrDefault(r => r.Id == id);

            if (recruitment == null)
            {
                return NotFound();
            }

            return Ok(recruitment);
        }

        public IActionResult Index([FromQuery] string? keyword=null, [FromQuery] int page = 1, [FromQuery] string? location = null, [FromQuery] string? branch = null)
        {
            var filteredRecruitments = Recruitments.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                filteredRecruitments = filteredRecruitments.Where(r => r.TenViTri.Contains(keyword, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(location))
            {
                filteredRecruitments = filteredRecruitments.Where(r => r.KhuVuc.Equals(location, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(branch))
            {
                filteredRecruitments = filteredRecruitments.Where(r => r.ChuyenNganh.Equals(branch, System.StringComparison.OrdinalIgnoreCase));
            }

            int pageSize = 10; // Define how many items per page
            var paginatedRecruitments = filteredRecruitments
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(paginatedRecruitments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return BadRequest("Error");
        }
    }
}