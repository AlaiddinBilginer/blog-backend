using BlogBackend.Domain.Common;

namespace BlogBackend.Domain.Entities;

public sealed class PostCategory : BaseEntity
{
    public Guid PostId { get; private set; }
    public Post Post { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    private PostCategory() { }

    public static PostCategory Create(Guid postId, Guid categoryId)
    {
        return new PostCategory 
        {  
            PostId = postId, 
            CategoryId = categoryId, 
            CreatedAt = DateTimeOffset.UtcNow 
        };
    }
}
