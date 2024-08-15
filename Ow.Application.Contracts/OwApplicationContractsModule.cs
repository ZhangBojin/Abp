using Ow.Domain.Share;
using Volo.Abp.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Ow.Application.Contracts
{
    [DependsOn(typeof(AbpDddApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(OwDomainShareModule))]
    public class OwApplicationContractsModule : AbpModule
    {

    }
}
