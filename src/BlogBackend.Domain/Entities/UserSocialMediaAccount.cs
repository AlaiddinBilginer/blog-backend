using BlogBackend.Domain.Common;
using BlogBackend.Domain.Enums;
using BlogBackend.Domain.Identity;

namespace BlogBackend.Domain.Entities;

public sealed class UserSocialMediaAccount : BaseEntity
{    
    public Guid UserId { get; private set; }
    public ApplicationUser User { get; private set; }
    
    public SocialMediaType SocialMediaType { get; private set; }
    public string Url { get; private set; }

    private UserSocialMediaAccount() { }

    public static UserSocialMediaAccount Create(Guid userId, SocialMediaType socialMediaType, string url)
    {
        return new UserSocialMediaAccount
        {
            Id = Guid.CreateVersion7(),
            UserId = userId,
            SocialMediaType = socialMediaType,
            Url = url,
            CreatedAt = DateTimeOffset.UtcNow
        };
    }

    public void UpdateUrl(string newUrl)
    {
        Url = newUrl;
    }
}
