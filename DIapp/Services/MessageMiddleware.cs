namespace DIapp.Services
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class MessageMiddleware
    {
        private readonly RequestDelegate next;
        public MessageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMessageSender messageSender)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(messageSender.Send());
        }
    }
}
