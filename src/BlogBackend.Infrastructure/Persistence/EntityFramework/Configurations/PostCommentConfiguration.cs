using BlogBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class PostCommentConfiguration : BaseEntityConfiguration<PostComment>
{
    public override void Configure(EntityTypeBuilder<PostComment> builder)
    {
        base.Configure(builder);

        builder.Property(pc => pc.Content)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasOne(pc => pc.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(pc => pc.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pc => pc.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(pc => pc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pc => pc.ParentComment)
            .WithMany(pc => pc.ChildComments)
            .HasForeignKey(pc => pc.ParentCommentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
