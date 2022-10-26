using ParticipationPortal.Domain.Errors.v1;
using System.Net;

namespace ParticipationPortal.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var error = exception switch
            {
                _ => new ApiError() { Message = "Internal Server Error", StatusCode = 500 }
            };


            context.Response.StatusCode = error.StatusCode;
            await context.Response.WriteAsync(error.ToString());
        }
    }
}
