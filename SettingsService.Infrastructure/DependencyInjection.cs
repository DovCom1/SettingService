using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SettingsService.Application.Interfaces;
using SettingsService.Infrastructure.Data;
using SettingsService.Infrastructure.Repositories;

namespace SettingsService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ISettingsService, SettingsRepository>();

        return services;
    }
}