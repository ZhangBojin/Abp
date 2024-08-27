using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Helper
{
    public static class JwtHelper
    {
        public static string GenerateJwtToken(string user)
        {
            // 设置JWT的密钥
            const string secretKey = "{19B2CAF7-095D-44E9-A45D-C8A8F5C16414}";
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var securityKey = new SymmetricSecurityKey(keyBytes);

            // 创建JWT的签名凭证
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // 设置JWT的Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user),
                // 添加其他需要的声明
            };

            // 创建JWT的Token
            var token = new JwtSecurityToken(
                issuer: "zbj",
                audience: "ZBJ",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials
            );

            // 生成JWT字符串
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
