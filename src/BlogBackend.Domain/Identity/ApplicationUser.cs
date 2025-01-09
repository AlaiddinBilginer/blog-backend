using BlogBackend.Domain.Common;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace BlogBackend.Domain.Identity;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public FullName FullName { get; set; }
    public string Bio { get; set; }
    public string ProfilePicturePath { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public ICollection<Post> Posts { get; private set; } = [];
    public ICollection<PostComment> Comments { get; private set; } = [];
    public ICollection<PostLike> Likes { get; private set; } = [];
    public ICollection<PostCategory> Categories { get; private set; } = [];
    public ICollection<UserFavoritePost> UserFavoritePosts { get; private set; } = [];

    private ApplicationUser() { }

    public static ApplicationUser Create(string email, string userName, FullName fullName, string bio, string profilePicturePath, bool isEmailConfirmed = false)
    {
        return new ApplicationUser 
        { 
            Email = email, 
            UserName = userName, 
            FullName = fullName, 
            Bio = bio, 
            ProfilePicturePath = profilePicturePath,
            EmailConfirmed = isEmailConfirmed,
            CreatedAt = DateTimeOffset.UtcNow,
        };
    }
}
