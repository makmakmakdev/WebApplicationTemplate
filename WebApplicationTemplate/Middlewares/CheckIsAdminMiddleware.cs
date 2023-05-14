using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplicationTemplate.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckIsAdminMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckIsAdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower().Contains("admin")
                && httpContext.GetEndpoint() != null
                && !httpContext.GetEndpoint().ToString().Contains("Login")
                && httpContext.Session.GetString("EmployeeNo") == null)
            {
                httpContext.Session.SetString("ReturnUrl", httpContext.Request.Path);
                httpContext.Response.Redirect("/Admin/Login");
                return;
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AdminCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseAdminCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckIsAdminMiddleware>();
        }
    }
}
