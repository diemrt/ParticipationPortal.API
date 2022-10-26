using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using ParticipationPortal.API.Middlewares;
using ParticipationPortal.Domain.Errors.v1;
using System.Net;

namespace ParticipationPortal.API.Extensions
{
    public static class ExceptionsMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
