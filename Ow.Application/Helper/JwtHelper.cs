using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ow.Application.Helper
{
    public class JwtHelper(IConfiguration configuration)
    {

        public string GenerateJwtToken(string name, string role, string email)
        {
            // 设置JWT的密钥
            var secretKey = configuration["Authentication:JwtBearer:SecurityKey"]!;
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var securityKey = new SymmetricSecurityKey(keyBytes);

            // 创建JWT的签名凭证
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // 设置JWT的Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,name),
                new Claim(ClaimTypes.Role,role),
                new Claim(ClaimTypes.Email, email),
                // 添加其他需要的声明
            };

            // 创建JWT的Token
            var token = new JwtSecurityToken(
                issuer: configuration["Authentication:JwtBearer:Issuer"]!,
                audience: configuration["Authentication:JwtBearer:Audience"]!,
                claims: claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: signingCredentials
            );

            // 生成JWT字符串
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        public ClaimsPrincipal DecodeJwtToken(string token)
        {
            // 获取JWT的密钥
            var secretKey = configuration["Authentication:JwtBearer:SecurityKey"]!;
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var securityKey = new SymmetricSecurityKey(keyBytes);

            // 创建Token验证参数
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],
                ValidAudience = configuration["Authentication:JwtBearer:Audience"],
                IssuerSigningKey = securityKey
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                // 验证并解析JWT
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                // 可选：验证token类型
                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    // 确保 token 是你期望的类型
                    if (jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return principal;
                    }
                }
            }
            catch (Exception ex)
            {
                // 捕获任何可能的异常，例如 Token 无效
                // 记录异常或处理异常
                throw new SecurityTokenException("Invalid token", ex);
            }

            // 如果 token 无效或解析失败，返回 null 或抛出异常
            return null;
        }
    }
}
