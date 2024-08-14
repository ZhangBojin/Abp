using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Ow.Domain.Share
{
    [DependsOn(typeof(AbpDddDomainSharedModule))]
    public class OwDomainShareModule : AbpModule
    {

    }
}
