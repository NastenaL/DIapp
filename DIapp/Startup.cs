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
            services.AddScoped<ICounter, RandomCounter>();
            services.AddScoped<CounterService>();
          
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CounterMiddleware>();
        }
    }
}

