using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace OnlineStore.MiddlewareHandlers
{


    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Cookies["jwtToken"];

            if (!string.IsNullOrEmpty(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                var exp = jwtToken.ValidTo;

                if (exp > DateTime.UtcNow)
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                else
                {
                    context.Response.Cookies.Delete("jwtToken");
                }
            }

            await _next(context);
        }

    }

}
