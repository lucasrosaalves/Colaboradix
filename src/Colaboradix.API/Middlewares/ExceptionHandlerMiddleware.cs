using Colaboradix.Application.Common.Constants;
using Colaboradix.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using ApplicationException = Colaboradix.Application.Common.Exceptions.ApplicationException;

namespace Colaboradix.API.Middlewares
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
            catch(ApplicationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(ex.ApplicationResponse);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                string errorMsg = ApplicationErrors.UnexpectedError;

                #if DEBUG

                errorMsg = ex.Message;

                #endif

                await context.Response.WriteAsJsonAsync(ApplicationResponse.Failure(errorMsg));
            }
        }
    }
}
