using BlogBackend.Domain.Entities;
using BlogBackend.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace BlogBackend.Domain.Identity;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public FullName FullName { get; private set; }
    public string? Bio { get; private set; }
    public string? ProfilePicturePath { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public ICollection<Post> Posts { get; private set; } = [];
    public ICollection<PostComment> Comments { get; private set; } = [];
    public ICollection<PostLike> Likes { get; private set; } = [];
    public ICollection<UserFavoritePost> UserFavoritePosts { get; private set; } = [];
    public ICollection<UserSocialMediaAccount> SocialMediaAccounts { get; private set; } = [];

    private ApplicationUser() { }

    public static ApplicationUser Create(string email, string userName, string fullName, string bio, string? profilePicturePath, bool isEmailConfirmed = false)
    {
        return new ApplicationUser 
        { 
            Email = email, 
            UserName = userName, 
            FullName = FullName.Create(fullName), 
            Bio = bio, 
            ProfilePicturePath = profilePicturePath,
            EmailConfirmed = isEmailConfirmed,
            CreatedAt = DateTimeOffset.UtcNow,
        };
    }

    public void UpdateProfile(string fullName, string bio, string profilePicturePath) 
    {
        FullName = FullName.Create(fullName);
        Bio = bio;
        ProfilePicturePath = profilePicturePath;
    }
}
