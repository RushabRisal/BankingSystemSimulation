using BankingSystem.Application.DTOs.SystemDto;
using BankingSystem.Domain.DomainException;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace BankingSystem.API.ExceptionCatcher
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";
            var (statusCode, message) = exception switch
            {
                EmailException ex =>
                    (ex.StatusCode, ex.Message),
                _ => ((int)HttpStatusCode.InternalServerError, exception.Message)
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(new ExceptionDto
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
            return true;
        }
    }
}
