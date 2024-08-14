using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ow.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace Ow.EntityFrameworkCore
{
    [DependsOn(typeof(OwDomainModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class OwEfCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<OwDbContext>(options => { //注入上下文对象
                options.AddDefaultRepositories(includeAllEntities: true);//自动为DbContext中的实体创建默认仓储,默认是为继承了Entity<Guid>的实体创建仓储，如果其他实体也要创建，必须设置includeAllEntities: true


            }); //配置注入
            Configure<AbpDbContextOptions>(options => {
                options.UseSqlServer(); //选择使用mysql数据库
            });
        }
    }
}
