using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using BlogBackend.Application.Common.Models.Errors;
using BlogBackend.Application.Common.Models.Responses;

namespace BlogBackend.WebApi.Middlewares;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";

        ResponseDto<string> errorResponse;
        int statusCode = (int)HttpStatusCode.InternalServerError;

        if (exception is ValidationException validationException)
        {
            statusCode = (int)HttpStatusCode.BadRequest;

            var validationErrors = validationException.Errors
                .GroupBy(e => e.PropertyName)
                .Select(g => new ValidationError(g.Key, g.Select(e => e.ErrorMessage)))
                .ToList();

            errorResponse = ResponseDto<string>.Error("Validasyon Hatası", validationErrors);
        }
        else
        {
            errorResponse = ResponseDto<string>.Error(exception.Message);
        }

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

        return true;
    }
}
