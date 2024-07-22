
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace MiniTransaction.WebApi.Middleware
{
    public class ApiExceptionHandlerMiddleware(RequestDelegate _next, ILogger<ApiExceptionHandlerMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = ex switch
                {
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                var problemsDetails = new ProblemDetails
                {
                    Status = response.StatusCode,
                    Title = ex.Message,
                };

                logger.LogError(ex.Message);
                var result = JsonSerializer.Serialize(problemsDetails);
                await response.WriteAsync(result);
            }
        }
    }
}
