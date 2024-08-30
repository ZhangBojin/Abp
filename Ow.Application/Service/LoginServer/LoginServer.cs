using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Ow.Application.Helper;
using Ow.Domain.Entities.UserDto;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Ow.Application.Service.LoginServer
{
    public class LoginServer(SignInManager<IdentityUser> signInManager
        , IdentityUserManager identityUserManager
        ,IConfiguration iConfiguration) : ApplicationService
    {

        [AllowAnonymous]
        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            var user =await identityUserManager.FindByEmailAsync(userLoginDto.UserEmail);
            var role=await identityUserManager.GetRolesAsync(user!);
            if (user == null) return "未找到该用户！";
            var result = await signInManager.PasswordSignInAsync(user.UserName, userLoginDto.Password, false, true);
            if (!result.Succeeded) return "账户或密码错误！";
            var token = new JwtHelper(iConfiguration).GenerateJwtToken(user.UserName, role[0],userLoginDto.UserEmail);
            return token;
        }

    }

}

