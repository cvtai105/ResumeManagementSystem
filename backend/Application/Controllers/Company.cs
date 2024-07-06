using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    [Route("api/company")]
    public class Company : ControllerBase
    {
        private readonly ILogger<Company> _logger;

        public Company(ILogger<Company> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}/avatar")]
        public IActionResult Index(int id)
        {
            //get avatar from "StaticFiles/images/DoanhNghiep/Avatars" folder
            _logger.LogInformation($"Get company avatar with id {id}");

            

            return Ok("Company avatar");
        }

    }
}