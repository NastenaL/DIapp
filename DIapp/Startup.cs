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
            services.AddTransient<IMessageSender, EmailMessageSender>();
        }

        public void Configure(IApplicationBuilder app, IMessageSender sender)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(sender.Send());
            });
        }
    }
}

