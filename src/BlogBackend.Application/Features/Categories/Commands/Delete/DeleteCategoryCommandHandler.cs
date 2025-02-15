using BlogBackend.Application.Common.Interfaces;
using BlogBackend.Application.Common.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Application.Features.Categories.Commands.Delete;

public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResponseDto<Guid>>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseDto<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _context.Categories.Where(c => c.Id == request.Id).ExecuteDeleteAsync(cancellationToken);

        return ResponseDto<Guid>.Success(request.Id, "Kategori silme işlemi başarılı");
    }
}
