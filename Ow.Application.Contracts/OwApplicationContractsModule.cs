using Ow.Domain.Share;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Ow.Application.Contracts
{
    [DependsOn(typeof(AbpDddApplicationContractsModule),
        typeof(OwDomainShareModule))]
    public class OwApplicationContractsModule : AbpModule
    {

    }
}
