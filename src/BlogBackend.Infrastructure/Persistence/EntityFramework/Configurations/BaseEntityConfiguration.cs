using BlogBackend.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.CreatedByUserId)
            .HasColumnType("text")
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.ModifiedByUserId)
            .HasColumnType("text")
            .IsRequired(false);

        builder.Property(e => e.ModifiedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Ignore(e => e.DomainEvents);
    }
}
