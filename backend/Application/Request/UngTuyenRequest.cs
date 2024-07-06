using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Request
{
    public class UngTuyenRequest
    {
        public IFormFile? Cv { get; set; } 
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public int DangTuyenId { get; set; }

    }
}