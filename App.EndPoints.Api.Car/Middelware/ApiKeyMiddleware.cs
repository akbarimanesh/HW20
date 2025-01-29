
using App.Domain.Core.Car.Configs;

namespace App.EndPoints.Api.Car.Middelware
{
   
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SiteSettings _siteSettings;
        

        public ApiKeyMiddleware(RequestDelegate next, SiteSettings siteSettings)
        {
            _next = next;
            _siteSettings = siteSettings;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();
            if (path.StartsWith("/model" ))
            {

                if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKey) && string.IsNullOrEmpty(apiKey))
                {
                    
                        await context.Response.WriteAsync("کلید نادرست است.");
                        return;
                    
                }
                if (apiKey != _siteSettings.ApiKey)
                {
                    await context.Response.WriteAsync("کلید ارسال نشده است.");
                    return;
                }
               
            }
            await _next(context);
        }
    }
}
