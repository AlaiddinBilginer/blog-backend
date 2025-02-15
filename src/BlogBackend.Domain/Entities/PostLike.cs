using BlogBackend.Domain.Common;
using BlogBackend.Domain.Identity;

namespace BlogBackend.Domain.Entities;

public sealed class PostLike : BaseEntity
{
    public Guid PostId { get; private set; }
    public Post Post { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    private PostLike() { }

    public static PostLike Create(Guid postId, Guid userId)
    {
        return new PostLike 
        { 
            PostId = postId, 
            UserId = userId, 
            CreatedAt = DateTimeOffset.UtcNow 
        };
    }
}
