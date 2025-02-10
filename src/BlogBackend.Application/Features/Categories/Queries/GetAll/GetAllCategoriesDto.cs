namespace BlogBackend.Application.Features.Categories.Queries.GetAll;

public sealed class GetAllCategoriesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImagePath { get; set; }
    public bool IsFeatured { get; set; }

    public GetAllCategoriesDto()
    {
        
    }

    public GetAllCategoriesDto(Guid id, string name, string description, bool isFeatured, string? imagePath) 
    {
        Id = id;
        Name = name;
        Description = description;
        ImagePath = imagePath;
        IsFeatured = isFeatured;
    }
}
