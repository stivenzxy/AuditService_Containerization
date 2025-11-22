using AuditService.Interfaces;
using AuditService.Persistence;
using AuditService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("La cadena de conexión 'PostgresConnection' no se encontró.");
        }
        
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        services.AddScoped<IAuditRepository, AuditRepository>();
        services.AddScoped<IAuditService, Services.AuditService>();
        
        return services;
    }
}