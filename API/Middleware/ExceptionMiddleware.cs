using System.Net;
using System.Text.Json;

namespace API;

public class ExceptionMiddleware
{
    //
    private readonly RequestDelegate _next;
    //ILogger to create logs
    private readonly ILogger<ExceptionMiddleware> _logger;
    //IHostEnvironment mode of ENVIRONMENT (production or development)
    private readonly IHostEnvironment _env;
    public ExceptionMiddleware(
        RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env) 
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            //Log to the terminal
            _logger.LogError(ex, ex.Message);
            //return client
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            //IF STATEMENT
            var response = _env.IsDevelopment()
                ? new APIException(context.Response.StatusCode, ex.Message,ex.StackTrace?.ToString())
                : new APIException(context.Response.StatusCode, ex.Message,"Internal Server Error");

            //Response Json object response
            var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};   
            //Create json response object
            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}
