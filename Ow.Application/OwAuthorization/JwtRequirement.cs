using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ow.Application.OwAuthorization
{
    public class JwtRequirement(string role) : IAuthorizationRequirement
    {
        public string Role { get; set; } = role;
    }
}
