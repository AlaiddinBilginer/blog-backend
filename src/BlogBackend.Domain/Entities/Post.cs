using BlogBackend.Domain.Common;
using BlogBackend.Domain.Identity;

namespace BlogBackend.Domain.Entities;

public sealed class Post : BaseEntity
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string ThumbnailPath { get; set; }
    public bool IsPublished { get; private set; }
    public bool IsFeatured { get; set; }
    public DateTimeOffset? PublishedAt { get; private set; }
    public int LikeCount { get; private set; }
    public int ReadingTimeInMinutes { get; set; }

    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }

    public ICollection<PostComment> Comments { get; private set; } = [];
    public ICollection<PostLike> Likes { get; private set; } = [];
    public ICollection<PostCategory> Categories { get; private set; } = [];
    public ICollection<UserFavoritePost> UserFavoritePosts { get; private set; } = [];

    private Post() { }
    
    public static Post Create(string title, string content, string description, string slug, string thumbnailPath, Guid userId, bool isPublished, bool isFeatured, int readingTimeInMinutes)
    {
        return new Post 
        {
            Id = Guid.CreateVersion7(),
            Title = title,
            Content = content,
            Description = description,
            UserId = userId,
            Slug = slug,
            ThumbnailPath = thumbnailPath,
            IsPublished = isPublished,
            IsFeatured = isFeatured,
            ReadingTimeInMinutes = readingTimeInMinutes,
            CreatedAt = DateTimeOffset.UtcNow,
        };
    }
    
    public void Publish()
    {
        IsPublished = true;
        PublishedAt = DateTimeOffset.UtcNow;
    }

    public void Unpublish()
    {
        IsPublished = false;
    }

    public void IncrementLikeCount()
    {
        LikeCount++;
    }

    public void DecrementLikeCount()
    {
        if (LikeCount > 0)
            LikeCount--;
    }
}
