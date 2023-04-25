﻿using ScheduleCore.Exceptions;

namespace ScheduleCore.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }

            catch (NotFoundException notfound)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notfound.Message);
            }
            catch (ForbiddenException forbidden)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(forbidden.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal server error");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
