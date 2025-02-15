using BlogBackend.Application.Common.Interfaces;
using BlogBackend.Application.Common.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Application.Features.Categories.Commands.Update;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResponseDto<Guid>>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseDto<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _context.Categories.Where(c => c.Id == request.Id)
            .ExecuteUpdateAsync(x => x.SetProperty(c => c.Name, request.Name)
            .SetProperty(c => c.Description, request.Description)
            .SetProperty(c => c.IsFeatured, request.IsFeatured), cancellationToken);

        return ResponseDto<Guid>.Success(request.Id, "Kategori güncelleme işlemi başarılı");   
    }
}
