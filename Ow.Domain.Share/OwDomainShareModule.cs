using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ow.Domain.Share
{
    [DependsOn(typeof(AbpDddDomainSharedModule)
        ,typeof(AbpPermissionManagementDomainSharedModule)
        ,typeof(AbpIdentityDomainSharedModule))]
    public class OwDomainShareModule : AbpModule
    {

    }
}
