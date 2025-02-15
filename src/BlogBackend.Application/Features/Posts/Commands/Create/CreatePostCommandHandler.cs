using BlogBackend.Application.Common.Interfaces;
using BlogBackend.Application.Common.Models.Responses;
using BlogBackend.Domain.Entities;
using MediatR;

namespace BlogBackend.Application.Features.Posts.Commands.Create;

public sealed class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ResponseDto<Guid>>
{
    private readonly IApplicationDbContext _context;

    public CreatePostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseDto<Guid>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = Post.Create(request.Title, request.Content, request.Description, request.Slug, request.UserId, request.ReadingTimeInMinutes, default);

        if (request.IsPublished)
            post.MarkAsFeatured();
        if (request.IsPublished)
            post.Publish();

        _context.Posts.Add(post);
        await _context.SaveChangesAsync(cancellationToken);

        return ResponseDto<Guid>.Success(post.Id, "Blog oluşturma işlemi başarılı");
    }
}
