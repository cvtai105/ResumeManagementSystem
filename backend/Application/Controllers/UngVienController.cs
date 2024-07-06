using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    [Route("api/ungvien")]
    public class UngVienController : ControllerBase
    {
        private readonly UngVienBL _ungVienBL;
        private readonly ILogger<UngVienController> _logger;

        public UngVienController(ILogger<UngVienController> logger, UngVienBL ungVienBL)
        {
            _ungVienBL = ungVienBL;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUngVien(int id)
        {
            _logger.LogInformation($"Get ung vien with id {id}");
            var result = await _ungVienBL.GetUngVien(id);

            return Ok(result);
        }

    }
}