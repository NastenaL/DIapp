namespace DIapp
{
    using System.Text;
    using DIapp.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTimeService();
        }

        public void Configure(IApplicationBuilder app, TimeService timeService)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html; sharset=utf-8";
                await context.Response.WriteAsync($"Current time is {timeService?.GetTime()}");
            });
        }
    }
}

