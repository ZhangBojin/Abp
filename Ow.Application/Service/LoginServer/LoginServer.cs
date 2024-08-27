using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Ow.Application.Service.LoginServer
{
    public class LoginServer(IdentityUserManager identityUserManager,IdentityRoleManager identityRoleManager) : ApplicationService
    {
        
        [AllowAnonymous]
        public void Login()
        {
        }
    }
}
