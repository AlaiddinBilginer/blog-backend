using BlogBackend.Application.Common.Interfaces;
using BlogBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Contexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<PostComment> PostComments { get; set; }
    public DbSet<PostLike> PostLikes { get; set; }  
    public DbSet<UserFavoritePost> UserFavoritePosts { get; set; }
    public DbSet<UserSocialMediaAccount> UserSocialMediaAccounts { get; set; }
}
