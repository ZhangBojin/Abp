using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Ow.Domain.Share
{
    [DependsOn(typeof(AbpDddDomainSharedModule),typeof(AbpIdentityDomainSharedModule))]
    public class OwDomainShareModule : AbpModule
    {

    }
}
