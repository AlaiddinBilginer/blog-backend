using BlogBackend.Domain.Common;

namespace BlogBackend.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public bool IsFeatured { get; set; }
    
    public ICollection<PostCategory> PostCategories { get; private set; } = [];

    private Category() { }

    public static Category Create(string name, string description, bool isFeatured)
    {
        return new Category
        {
            Id = Guid.CreateVersion7(),
            Name = name,
            Description = description,
            CreatedAt = DateTimeOffset.UtcNow,
            IsFeatured = isFeatured
        };
    }
}
