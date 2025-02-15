using BlogBackend.Application.Common.Models.Responses;
using BlogBackend.Application.Features.Categories.Commands.Create;
using BlogBackend.Application.Features.Categories.Commands.Delete;
using BlogBackend.Application.Features.Categories.Commands.Update;
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

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            })
            .Produces<ResponseDto<Guid>>();

        groupBuilder.MapDelete("deleteCategory/{id:guid}",
            async (Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                var response = await sender.Send(new DeleteCategoryCommand(id), cancellationToken);

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            })
            .Produces<ResponseDto<Guid>>();

        groupBuilder.MapPut("updateCategory",
            async (UpdateCategoryCommand request, ISender sender, CancellationToken cancellationToken) =>
            {
                var response = await sender.Send(request, cancellationToken);

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            })
            .Produces<ResponseDto<Guid>>();



    }
}
