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
            var (statusCode, message) = exception switch
            {
                EmailException ex =>
                    (HttpStatusCode.BadRequest, ex.Message),
                _ => (HttpStatusCode.InternalServerError, "Internal Server Error")
            };

            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsync(new ExceptionDto
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString(), cancellationToken: cancellationToken);
            return true;
        }
    }
}
