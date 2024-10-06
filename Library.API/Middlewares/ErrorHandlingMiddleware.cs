using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace Library.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
              await HandleExceptionAsync(context, exception);
            }   
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusDetails = GetStatusDetails(exception);

            context.Response.StatusCode = (int)statusDetails.StatusCode;

            var response = new
            {
                Title = statusDetails.Title,
                Status= context.Response.StatusCode,
                Detail = exception.Message
            };

            return context.Response.WriteAsJsonAsync(response);
        }

        private (HttpStatusCode StatusCode, string Title) GetStatusDetails(Exception exception)
        {
            return exception switch
            {
                UnauthorizedAccessException _ => GetStatusDetailsByStatusCode(HttpStatusCode.Unauthorized),
                ArgumentException _ => GetStatusDetailsByStatusCode(HttpStatusCode.BadRequest),
                NullReferenceException _ => GetStatusDetailsByStatusCode(HttpStatusCode.NotFound),
                TimeoutException _ => GetStatusDetailsByStatusCode(HttpStatusCode.GatewayTimeout),
                IndexOutOfRangeException _ => GetStatusDetailsByStatusCode(HttpStatusCode.BadRequest),
                DbUpdateConcurrencyException _ => GetStatusDetailsByStatusCode(HttpStatusCode.Conflict),
                DbUpdateException _ => GetStatusDetailsByStatusCode(HttpStatusCode.InternalServerError),
                _ => GetStatusDetailsByStatusCode(HttpStatusCode.InternalServerError)// по умолчанию
            };
        }

        private (HttpStatusCode StatusCode, string Title) GetStatusDetailsByStatusCode(HttpStatusCode httpStatusCode)
        {
            return (httpStatusCode, httpStatusCode.ToString());
        }

    }
}
