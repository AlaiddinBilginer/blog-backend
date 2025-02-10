using BlogBackend.Application.Common.Models.Responses;
using BlogBackend.Application.Features.Categories.Commands.Create;
using MediatR;

namespace BlogBackend.WebApi.Modules;

public static class CategoryModule
{
    public static void RegisterCategoryRoutes(this IEndpointRouteBuilder routeBuilder)
    {
        RouteGroupBuilder groupBuilder = routeBuilder.MapGroup("/categories").WithTags("Categories");

        groupBuilder.MapPost("createCategory",
            async (ISender sender, CreateCategoryCommand request, CancellationToken cancellationToken) =>
            {
                var response = await sender.Send(request, cancellationToken);

                if(response.IsSuccess)
                    return Results.Ok(response);

                return Results.BadRequest(response);

            })
            .Produces<ResponseDto<Guid>>();

        
    }
}
