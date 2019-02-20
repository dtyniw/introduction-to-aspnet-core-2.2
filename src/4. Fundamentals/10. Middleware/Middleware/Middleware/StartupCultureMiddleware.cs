using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Middleware.Culture;
using System.Globalization;

namespace Middleware
{
    public class StartupCultureMiddleware
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseRequestCulture();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $"Hello {CultureInfo.CurrentCulture.DisplayName}");
            });

        }
    }
}
