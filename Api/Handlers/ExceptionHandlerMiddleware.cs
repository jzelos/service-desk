using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Api.Handlers
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }

    public class ExceptionHandlerMiddleware
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                var problemDetails = new ProblemDetails
                {
                    Instance = $"urn:orbis.housing.servicedesk:error:{Guid.NewGuid()}"
                };

                if (ex is BadHttpRequestException badHttpRequestException) // Kestral Internal Exceptions like 400 codes, TODO should argument exceptions be 400 codes?
                {
                    problemDetails.Title = "Invalid request";
                    problemDetails.Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException);
                    problemDetails.Detail = badHttpRequestException.Message;
                }
                else
                {
                    problemDetails.Title = "An unexpected error occurred!";
                    problemDetails.Status = 500;
                    problemDetails.Detail = ex.Message;
                };

                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
            }
        }
    }
}