using BlogBackend.Domain.Common;
using BlogBackend.Domain.Identity;

namespace BlogBackend.Domain.Entities;

public sealed class PostComment : BaseEntity
{
    public string Content { get; set; }
    
    public Guid PostId { get; private set; }
    public Post Post { get; private set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    public Guid? ParentCommentId { get; private set; }
    public PostComment ParentComment { get; private set; }

    public ICollection<PostComment> ChildComments { get; private set; } = [];

    private PostComment() { }

    public static PostComment Create(string content, Guid postId, Guid userId, Guid? parentCommentId)
    {
        return new PostComment
        {
            Content = content,
            PostId = postId,
            UserId = userId,
            ParentCommentId = parentCommentId,
            CreatedAt = DateTimeOffset.UtcNow
        };
    }
}
