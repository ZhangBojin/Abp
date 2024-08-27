using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Ow.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class OwDbContext:AbpDbContext<OwDbContext>
    {

        public OwDbContext(DbContextOptions<OwDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePermissionManagement();//配置权限管理模块
            //modelBuilder.ConfigureSettingManagement();//配置设置管理模块。
            //modelBuilder.ConfigureBackgroundJobs();//配置后台作业管理模块。
            //modelBuilder.ConfigureAuditLogging();//配置审计日志管理模块
            //modelBuilder.ConfigureFeatureManagement();// 配置功能管理模块。
            modelBuilder.ConfigureIdentity();//配置身份管理模块。
            //modelBuilder.ConfigureOpenIddict();//配置 OpenIddict 模块。
            //modelBuilder.ConfigureTenantManagement();//配置租户管理模块。
            //modelBuilder.ConfigureBlobStoring();//配置 Blob 存储模块。


        }
    }
}
