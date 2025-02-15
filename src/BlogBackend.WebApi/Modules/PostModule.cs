using BlogBackend.Application.Common.Models.Responses;
using BlogBackend.Application.Features.Posts.Commands.Create;
using MediatR;

namespace BlogBackend.WebApi.Modules;

public static class PostModule
{
    public static void RegisterPostRoutes(this IEndpointRouteBuilder routeBuilder)
    {
        RouteGroupBuilder groupBuilder = routeBuilder.MapGroup("/posts").WithTags("Posts");

        groupBuilder.MapPost("createPost",
            async (ISender sender, CreatePostCommand request, CancellationToken cancellationToken) =>
            {
                var response = await sender.Send(request, cancellationToken);

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            })
            .Produces<ResponseDto<Guid>>();
    }
}
