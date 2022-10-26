using ParticipationPortal.Domain.Errors.v1;
using ParticipationPortal.Domain.Errors.v1.Users;
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
                AlreadyPresentUserException e => new ApiError() { Message = e.Message, StatusCode = e.StatusCode, InnerMessage = e?.InnerException?.Message},
                _ => new ApiError() { Message = "Internal Server Error", StatusCode = 500, InnerMessage = exception.Message }
            };

            context.Response.StatusCode = error.StatusCode;
            await context.Response.WriteAsync(error.ToString());
        }
    }
}
