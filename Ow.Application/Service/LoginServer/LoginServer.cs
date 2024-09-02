using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Ow.Application.Helper;
using Ow.Domain.Entities.UserDto;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Ow.Application.Service.LoginServer
{
    public class LoginServer(SignInManager<IdentityUser> signInManager
        , IdentityUserManager identityUserManager
        , IPermissionGrantRepository repository
        , IConfiguration iConfiguration) : ApplicationService
    {

        [AllowAnonymous]
        public async Task<UserLoginResultDto> Login(UserLoginDto userLoginDto)
        {
            var user =await identityUserManager.FindByEmailAsync(userLoginDto.UserEmail);
            if (user == null) return new UserLoginResultDto(200,"账户或密码错误！");
            var role=await identityUserManager.GetRolesAsync(user!);
            var result = await signInManager.PasswordSignInAsync(user.UserName, userLoginDto.Password, false, true);
            if (!result.Succeeded) new UserLoginResultDto(200, "账户或密码错误！");
            var token = new JwtHelper(iConfiguration).GenerateJwtToken(user.UserName, role[0],userLoginDto.UserEmail);
            return new UserLoginResultDto(200, token); ;
        }

        [Authorize(IdentityPermissions.Roles.Create)]
        //[Authorize(Roles = "SuperAdministrator")]
        public async Task CS()
        {
            var a4 = await repository.InsertAsync(
                new PermissionGrant(
                    GuidGenerator.Create(),
                    IdentityPermissions.UserLookup.Default,
                    "R",
                    "SuperAdministrator",
                    CurrentTenant.Id
                ));
            return;
        }
    }

}

