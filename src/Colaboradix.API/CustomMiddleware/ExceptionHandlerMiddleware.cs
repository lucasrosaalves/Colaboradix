using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace Colaboradix.API.CustomMiddleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch
            {
                await HandleExceptionAsync(context);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Unexpected error ocurred. Contact the system's adminstrator";

            await response.WriteAsJsonAsync(new
            {
                Status = response.StatusCode,
                Message = message
            });
        }
    }
}
