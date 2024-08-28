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
        public async Task Login(UserLoginDto userLoginDto)
        {
            var result=await signInManager.PasswordSignInAsync(userLoginDto.UserName,userLoginDto.Password,false,true);
            if (result.Succeeded)
            {

            }
        }

    }

}

