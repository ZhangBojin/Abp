using Microsoft.AspNetCore.Identity;
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
using WebApplication1.OwAuthorization;


namespace WebApplication1
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpSwashbuckleModule),
        typeof(AbpAutofacModule),                                                  
        typeof(OwApplicationModule),
        typeof(OwEfCoreModule))]
    public class MainModule() : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);

            //配置 ASP.NET Core 的身份验证服务
            context.Services.AddIdentity<Volo.Abp.Identity.IdentityUser, Volo.Abp.Identity.IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.RequireUniqueEmail = true;
            });

            //配置了 ASP.NET Core 应用程序的身份验证方案
            context.Services.AddAuthentication(option =>
            {
                option.AddScheme<AuthenticationHandler>(AuthenticationHandler.SchemeDefault.Scheme, "Ow_Scheme");
                option.DefaultAuthenticateScheme = AuthenticationHandler.SchemeDefault.Scheme;
                option.DefaultChallengeScheme= AuthenticationHandler.SchemeDefault.Scheme;
                option.DefaultForbidScheme = AuthenticationHandler.SchemeDefault.Scheme;
                option.DefaultScheme= AuthenticationHandler.SchemeDefault.Scheme;
                option.DefaultSignInScheme= AuthenticationHandler.SchemeDefault.Scheme;
                option.DefaultSignOutScheme= AuthenticationHandler.SchemeDefault.Scheme;
            });

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

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication(); // 添加认证中间件
            app.UseAuthorization();  // 添加授权中间件

            app.UseConfiguredEndpoints();

        }

    }
}

