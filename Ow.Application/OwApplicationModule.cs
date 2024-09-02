using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ow.Application.Contracts;
using Ow.Domain;
using Volo.Abp.Account;
using Volo.Abp.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ow.Application
{
    [DependsOn(typeof(AbpDddApplicationModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpIdentityApplicationModule),
        typeof(OwApplicationContractsModule),
        typeof(OwDomainModule))]
    public class OwApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
