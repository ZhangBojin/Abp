using Ow.Application.Contracts;
using Ow.Domain;
using Volo.Abp.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ow.Application
{
    [DependsOn(typeof(AbpDddApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpIdentityApplicationModule),
        typeof(OwApplicationContractsModule),
        typeof(OwDomainModule))]
    public class OwApplicationModule : AbpModule
    {
    }
}
