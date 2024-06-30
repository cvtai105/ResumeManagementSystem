using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Models.RequestRecords
{
    public record LoginRecord(string Email, string Password);
}