using BlogBackend.Application.Common.Interfaces;
using BlogBackend.Infrastructure.Persistence.Dapper;
using BlogBackend.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YazilimAcademy.Infrastructure.Persistence.EntityFramework.Interceptors;

namespace BlogBackend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<EntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((provider, options) => {
            var entityInterceptor = provider.GetRequiredService<EntityInterceptor>();
            options.AddInterceptors(entityInterceptor);
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>(provider => new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
