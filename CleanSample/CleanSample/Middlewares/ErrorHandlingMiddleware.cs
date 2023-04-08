using CleanSample.Application.ApiResult;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CleanSample.Middlewares
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
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleError(exception, context);
            }
        }

        private async Task HandleError(Exception exception, HttpContext context)
        {
            var errorCode = exception.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(x => x.Name.Equals("ErrorStatusCode", StringComparison.OrdinalIgnoreCase))
                .GetValue(exception);


            if (int.TryParse(errorCode.ToString(), out int errorStatusCode) && errorStatusCode > 99 && errorStatusCode < 600)
            {
                context.Response.StatusCode = errorStatusCode;
            }

            context.Response.ContentType = "application/json";

            var genericResult = ApiResult<object>.ERROR(new List<Error>()
            {
                new Error()
                {
                    ErrorCode =errorStatusCode,
                    ErrorMessage = exception.Message,
                    HttpStatusCode = errorStatusCode
                }
            });

            await context.Response.WriteAsJsonAsync(genericResult);
        }


    }
}
