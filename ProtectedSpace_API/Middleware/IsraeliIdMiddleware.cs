using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ProtectedSpace_API.Middleware
{
    public class IsraeliIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public IsraeliIdMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            // בדיקה אם הנתיב מתחיל ב-/api/address
            if (path != null && path.StartsWith("/api/address"))
            {
                var id = context.Request.Query["id"].ToString();

                using (var scope = _serviceProvider.CreateScope())
                {
                    var services = scope.ServiceProvider.GetRequiredService<IServices_Address>();

                    if (string.IsNullOrWhiteSpace(id) || !services.IsIsraeliIdValid(id))
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("תעודת זהות אינה תקינה");
                        return; // חוסם המשך בקשה
                    }
                }
            }

            // ממשיך בשרשרת המידאלוור
            await _next(context);
        }
    }
}
