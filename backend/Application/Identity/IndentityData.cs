using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Identity
{
    public class IndentityData
    {
        public const string AdminClaimName = "admin";
        public const string AdminPolicyName = "Admin";
        
        public const string JobSeekerClaimName = "seeker";
        public const string JobSeekerPolicyName = "Seeker";
        public const string JobProviderClaimName = "jobProvider";
        public const string JobProviderPolicyName = "JobProvider";
    }
}