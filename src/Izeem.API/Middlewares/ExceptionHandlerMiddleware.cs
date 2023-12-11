using Izeem.API.Models;
using Izeem.Service.Exceptions;

namespace Izeem.API.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
        _request = request;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _request(context);
        }

        catch (IzeemException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = exception.StatusCode,
                Message = exception.Message
            });
        }

        catch (Exception exception)
        {
            _logger.LogError($"{exception}\n\n");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = 500,
                Message = exception.Message
            });
        }
    }
}