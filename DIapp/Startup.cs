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

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                IMessageSender messageSender = app.ApplicationServices.GetService<IMessageSender>();
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(messageSender.Send());
            });
        }
    }
}

