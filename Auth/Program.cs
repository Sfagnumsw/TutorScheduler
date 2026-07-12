using Auth.API.Middleware;
using Auth.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

namespace Auth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLocalization(); //options => options.ResourcesPath = "Infrastructure/Resources"
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Host.UseNLog();

            // Add services to the container.

            builder.Services.AddDbContext<EFContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PsqlConnectionString")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var supportedCultures = new[] { "ru", "en" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures);
            app.UseRequestLocalization(localizationOptions);

            app.UseMiddleware(typeof(GeneralExceptionHandling));

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
