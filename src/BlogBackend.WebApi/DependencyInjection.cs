using BlogBackend.Application.Common.Interfaces;
using BlogBackend.WebApi.Services;

namespace BlogBackend.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }
}
