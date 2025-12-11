using Microsoft.EntityFrameworkCore;
using SettingsService.Infrastructure;
using SettingsService.Infrastructure.Data;
using Microsoft.OpenApi;
using System.Text.Json.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Добавляем контроллеры с поддержкой enum → int в JSON
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });

        // Подключаем инфраструктуру (DbContext, ISettingsService и т.д.)
        builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"));

        var app = builder.Build();

        // Только маршрутизация — никаких Swagger, HTTPS, Auth — как в твоём другом микросервисе
        app.MapControllers();

        app.Run();
    }
}