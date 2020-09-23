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
            services.AddTransient<RandomCounter>();
            services.AddTransient<ICounter>(provider =>
            {
                var counter = provider.GetService<RandomCounter>();
                return counter;
            });
            services.AddTransient<CounterService>();

            services.AddTransient<IMessageSender>(provider => {

                if (DateTime.Now.Hour >= 12) return new EmailMessageSender();
                else return new SmsMessageSender();
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CounterMiddleware>();
        }
    }
}

