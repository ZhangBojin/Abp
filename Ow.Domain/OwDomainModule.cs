using Ow.Domain.Share;
using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectMapping;

namespace Ow.Domain
{
    [DependsOn(typeof(AbpDddDomainModule),
        typeof(AbpIdentityDomainModule),
        typeof(OwDomainShareModule),
        typeof(AbpObjectMappingModule))]
    public class OwDomainModule : AbpModule
    {

    }
}
