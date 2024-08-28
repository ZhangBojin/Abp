using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Ow.Application.Service.LoginServer
{
    public class LoginServer() : ApplicationService
    {
        
        [AllowAnonymous]
        public void Login()
        {

        }
    }
}
