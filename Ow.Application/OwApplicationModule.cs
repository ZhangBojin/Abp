using Ow.Application.Contracts;
using Ow.Domain;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Ow.Application
{
    [DependsOn(typeof(AbpDddApplicationModule),
        typeof(OwApplicationContractsModule),
        typeof(OwDomainModule))]
    public class OwApplicationModule : AbpModule
    {
    }
}
