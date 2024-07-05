using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ExampleDTO
    {
        public string? FullName { get; set; }
        public string? Email { get; set; } = String.Empty;
        public string? Password { get; set; } = String.Empty;
    }
}