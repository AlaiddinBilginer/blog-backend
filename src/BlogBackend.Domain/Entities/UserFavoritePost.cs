using BlogBackend.Domain.Common;
using BlogBackend.Domain.Identity;

namespace BlogBackend.Domain.Entities;

public sealed class UserFavoritePost : BaseEntity
{
    public Guid PostId { get; private set; }
    public Post Post { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    private UserFavoritePost() { }

    public static UserFavoritePost Create(Guid postId, Guid userId)
    {
        return new UserFavoritePost 
        { 
            PostId = postId, 
            UserId = userId, 
            CreatedAt = DateTimeOffset.UtcNow 
        };
    }
}
