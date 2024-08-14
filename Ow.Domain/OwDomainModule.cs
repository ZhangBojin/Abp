using Ow.Domain.Share;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectMapping;

namespace Ow.Domain
{
    [DependsOn(typeof(AbpDddDomainModule),
        typeof(OwDomainShareModule),
        typeof(AbpObjectMappingModule))]
    public class OwDomainModule : AbpModule
    {

    }
}
