using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BlogBackend.WebApi.Controllers.OData;

public static class ODataServiceExtensions
{
    public static IServiceCollection AddCustomData(this IServiceCollection services)
    {
        services.AddControllers()
            .AddOData(opt =>
            {
                opt.Select().Filter().Expand().OrderBy().Count().SetMaxTop(null)
                    .AddRouteComponents("odata", GetEdmModel());
            });

        return services;
    }

    private static IEdmModel GetEdmModel()
    {
        var modelBuilder = new ODataConventionModelBuilder();
        return modelBuilder.GetEdmModel();
    }
}
