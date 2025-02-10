using BlogBackend.Application.Common.Interfaces;
using BlogBackend.Application.Common.Models.Responses;
using BlogBackend.Domain.Entities;
using MediatR;

namespace BlogBackend.Application.Features.Categories.Commands.Create;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResponseDto<Guid>>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseDto<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name, request.Description, default);

        if (request.IsFeatured)
            category.MarkAsFeatured();
        else 
            category.UnmarkAsFeatured();

        _context.Categories.Add(category);

        await _context.SaveChangesAsync(cancellationToken);

        return ResponseDto<Guid>.Success(category.Id, "Kategori oluşturma işlemi başarılı");
    }
}
