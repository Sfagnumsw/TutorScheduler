using Auth.Infrastructure.Resources;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Auth.API.Middleware
{
    public class GeneralExceptionHandling
    {
        private readonly RequestDelegate nextComponent;
        private readonly IStringLocalizer<DefaultResource> localizer;
        private readonly ILogger logger;
        public GeneralExceptionHandling(RequestDelegate nextComponent, IStringLocalizer<DefaultResource> localizer, ILogger logger)
        {
            this.nextComponent = nextComponent;
            this.localizer = localizer;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await nextComponent(context); // Передаём управление дальше по конвейеру
            }
            catch (Exception ex)
            {
                logger.LogError(ex, localizer[DefaultResource.MiddlewareExceptionMessage], context.Request.Method, context.Request.Path);
                await HandleException(context, ex);
            }
        }

        public Task HandleException(HttpContext context, Exception ex)
        {
            var statusCode = ex switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var responce = new {error = ex.Message};
            return context.Response.WriteAsJsonAsync(responce);
        }
    }
}
