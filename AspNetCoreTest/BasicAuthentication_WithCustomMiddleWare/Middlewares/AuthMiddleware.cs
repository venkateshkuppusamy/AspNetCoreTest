using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BasicAuthentication_WithCustomMiddleWare.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    var credentials = Encoding.UTF8
                                        .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                        .Split(':', 2);
                    if (credentials.Length == 2)
                    {
                        if ((credentials[0] != "admin") || (credentials[1] != "password"))
                        {
                            context.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"Basic\"";
                            context.Response.StatusCode = 401;
                            return Task.Delay(0);
                        }
                    }
                }
            }
            else
            {
                context.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"Basic\"";
                context.Response.StatusCode = 401;
                return Task.Delay(0);
            }
            return _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
