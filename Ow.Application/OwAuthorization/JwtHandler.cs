using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Ow.Application.OwAuthorization
{
    public class JwtHandler: AuthorizationHandler<JwtRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, JwtRequirement requirement)
        {
            var httpContext = (context.Resource as HttpContext);
            var token = httpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var isValidToken = ValidateToken(token);
            if (isValidToken)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }

        private bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("yourSecretKey"); // 应该与配置中的密钥匹配

            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourIssuer", // 配置中的发行者
                    ValidAudience = "yourAudience", // 配置中的受众
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                // 这里可以根据需要检查 `principal` 的 Claims 等
                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                // 令牌已过期
                return false;
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                // 令牌签名无效
                return false;
            }
            catch (SecurityTokenInvalidIssuerException)
            {
                // 令牌发行者无效
                return false;
            }
            catch (SecurityTokenInvalidAudienceException)
            {
                // 令牌受众无效
                return false;
            }
            catch (Exception)
            {
                // 其他验证异常
                return false;
            }
        }
    }
}
