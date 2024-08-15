using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Ow.Application.Service.UserManage
{
    public class MyUserMangerService(IIdentityUserAppService identityUserAppService) : ApplicationService
    {
        private readonly IIdentityUserAppService _identityUserAppService = identityUserAppService;

        public async Task CreateUserAsync()
        {
            var input = new IdentityUserCreateDto
            {
                UserName = "newuser",
                Email = "newuser@example.com",
                Password = "1q2w3E*"
            };

            await _identityUserAppService.CreateAsync(input);
        }
    }

}
