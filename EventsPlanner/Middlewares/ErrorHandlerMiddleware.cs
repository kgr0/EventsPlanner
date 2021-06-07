using EventsPlanner.BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventsPlanner.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = e.StatusCode;
                await response.WriteAsync(SerializeToJson(e?.Message));
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsync(SerializeToJson(e?.Message + " " + e?.InnerException?.Message));
            }
        }
        private string SerializeToJson(string message)
        {
            return JsonSerializer.Serialize(new { message = message });
        }

    }
}
