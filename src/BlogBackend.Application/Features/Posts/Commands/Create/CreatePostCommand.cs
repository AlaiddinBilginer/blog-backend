using BlogBackend.Application.Common.Models.Responses;
using MediatR;

namespace BlogBackend.Application.Features.Posts.Commands.Create;

public sealed record CreatePostCommand(
    string Title,
    string Content,
    string Description,
    string Slug,
    int ReadingTimeInMinutes,
    bool IsPublished,
    bool IsFeatured,
    Guid UserId) : IRequest<ResponseDto<Guid>>;
