using BlogBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Post> Posts { get; }
    DbSet<Category> Categories { get; }
    DbSet<PostCategory> PostCategories { get; }
    DbSet<PostComment> PostComments { get; }
    DbSet<PostLike> PostLikes { get; }
    DbSet<UserFavoritePost> UserFavoritePosts { get; }
    DbSet<UserSocialMediaAccount> UserSocialMediaAccounts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
