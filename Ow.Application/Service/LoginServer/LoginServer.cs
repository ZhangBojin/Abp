using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Ow.Domain.Entities.UserDto;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Ow.Application.Service.LoginServer
{
    public class LoginServer(SignInManager<IdentityUser> signInManager) : ApplicationService
    {

        [AllowAnonymous]
        public  Task Login1(UserLoginDto userLoginDto)
        {
            //var result = await signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, true);
            //if (result.Succeeded)
            //{

            //}
            return Task.CompletedTask;
        }

        [Authorize(Roles = "admin")]
        public string Login2(UserLoginDto userLoginDto)
        {

            return "成功";
        }

    }

}

