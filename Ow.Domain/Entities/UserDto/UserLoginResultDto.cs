using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ow.Domain.Entities.UserDto
{
    public class UserLoginResultDto(int code, string message)
    {
        public int Code { get; set; } = code;
        public string Message { get; set; } = message;
    }
}
