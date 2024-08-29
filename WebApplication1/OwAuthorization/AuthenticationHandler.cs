using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApplication1.OwAuthorization
{
    public class AuthenticationHandler : IAuthenticationHandler
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
            var a = _context.Request.Body;
            var b= _context.Request.Headers.Authorization;
            if (b == "222222")
            {
                var claim = new ClaimsIdentity("Custom");
                claim.AddClaim(new Claim(ClaimTypes.Name,"zbj"));
                claim.AddClaim(new Claim(ClaimTypes.Role,"admin"));
                ClaimsPrincipal principal = new ClaimsPrincipal(claim);
                return Task.FromResult<AuthenticateResult>(AuthenticateResult.Success(new AuthenticationTicket(principal, SchemeDefault.Scheme)));
            }

            return Task.FromResult<AuthenticateResult>(AuthenticateResult.Fail("失败"));
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

    }


    public class SchemeDefault
    {
        public const string Scheme = "Ow";
    }

}
