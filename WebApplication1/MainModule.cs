using Microsoft.OpenApi.Models;
using Ow.Application;
using Ow.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace WebApplication1
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpSwashbuckleModule),
        typeof(AbpAutofacModule),                                                  
        typeof(OwApplicationModule),
        typeof(OwEfCoreModule))]
    public class MainModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);

            //ConfigureAuthentication(context);
            context.Services.AddControllers();
            context.Services.AddEndpointsApiExplorer();
            context.Services.AddAbpSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "OW API", Version = "v1" });
                opt.DocInclusionPredicate((docName, description) => true);
                opt.CustomSchemaIds(type => type.FullName);
            });

            //配置反跨站请求伪造（CSRF）保护
            Configure<AbpAntiForgeryOptions>(opt =>
            {
                opt.AutoValidate = false;// 禁用自动验证
            });

            //动态Api
            Configure<AbpAspNetCoreMvcOptions>(opt =>
            {
                opt.ConventionalControllers.Create(typeof(OwApplicationModule).Assembly);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            base.OnApplicationInitialization(context);
            var app = context.GetApplicationBuilder();

            app.UseRouting();

            app.UseAuthentication(); // 添加认证中间件
            app.UseAuthorization();  // 添加授权中间件

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseConfiguredEndpoints();

        }

    }
}

