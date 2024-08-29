using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ow.Domain.Entities.UserDto
{
    public class UserLoginDto(string userEmail, string password)
    {
        public string UserEmail { get; set; } = userEmail;
        public string Password { get; set; } = password;
    }
}
