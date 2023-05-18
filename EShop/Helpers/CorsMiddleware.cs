using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EShop.Helpers
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            await _next(context);
        }
    }

}
