using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace GamesApi.Exception;

public static class ExceptionMiddleware
{
    /// <summary>
    /// Добавляет обработку внезапных ошибок
    /// </summary>
    /// <param name="app"></param>
    public static void UseGenericExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var error = context.Features?.Get<IExceptionHandlerFeature>()?.Error;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(error?.Message));
            });
        });
    }
}
