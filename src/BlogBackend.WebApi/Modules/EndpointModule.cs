namespace BlogBackend.WebApi.Modules;

public static class EndpointModule
{
    public static void MapEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.RegisterCategoryRoutes();
    }
}
