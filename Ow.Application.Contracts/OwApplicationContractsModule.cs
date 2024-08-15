using Ow.Domain.Share;
using Volo.Abp.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ow.Application.Contracts
{
    [DependsOn(typeof(AbpDddApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(OwDomainShareModule))]
    public class OwApplicationContractsModule : AbpModule
    {

    }
}
