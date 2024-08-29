using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.Primitives;
using Ow.Application.Helper;

namespace WebApplication1.OwAuthorization
{
    public class AuthenticationHandler(IConfiguration configuration) : IAuthenticationHandler
    {

        private Microsoft.AspNetCore.Http.HttpContext _context = null!;
        private AuthenticationScheme? _scheme;

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            _context = context;
            _scheme = scheme;
            return Task.CompletedTask;
        }

        public Task<AuthenticateResult> AuthenticateAsync()
        {
            var token = _context.Request.Headers.Authorization;
            if(token == StringValues.Empty)  return Task.FromResult<AuthenticateResult>(AuthenticateResult.Fail("Token is missing"));
            var data = new JwtHelper(configuration).DecodeJwtToken(token!);

            var claim = new ClaimsIdentity();
            claim.AddClaim(new Claim(ClaimTypes.Name, data.FindFirst(ClaimTypes.Name)!.Value));
            claim.AddClaim(new Claim(ClaimTypes.Role, data.FindFirst(ClaimTypes.Role)!.Value));
            claim.AddClaim(new Claim(ClaimTypes.Email, data.FindFirst(ClaimTypes.Email)!.Value));
            var principal = new ClaimsPrincipal(claim);
            return Task.FromResult<AuthenticateResult>(
                AuthenticateResult.Success(new AuthenticationTicket(principal, SchemeDefault.Scheme)));

        }

        /// <summary>
        /// 没登陆
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task ChallengeAsync(AuthenticationProperties? properties)
        {
            _context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 没权限
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task ForbidAsync(AuthenticationProperties? properties)
        {
            _context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        }


        public class SchemeDefault
        {
            public const string Scheme = "Ow";
        }

    }
}