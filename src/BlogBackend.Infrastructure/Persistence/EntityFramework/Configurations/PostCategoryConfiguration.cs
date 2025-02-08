using BlogBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class PostCategoryConfiguration : BaseEntityConfiguration<PostCategory>
{
    public override void Configure(EntityTypeBuilder<PostCategory> builder)
    {
        base.Configure(builder);

        builder.HasOne(pc => pc.Post)
            .WithMany(p => p.Categories)
            .HasForeignKey(pc => pc.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pc => pc.Category)
            .WithMany(c => c.PostCategories)
            .HasForeignKey(pc => pc.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(pc => new { pc.PostId, pc.CategoryId })
            .IsUnique();
    }
}
