using BlogBackend.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olmalıdır")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır")
            .MustAsync(IsNameUniqueAsync).WithMessage("Bu kategori adı zaten mevcuttur");

        RuleFor(x => x.Description)
            .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.Description)).WithMessage("Kategori açıklaması boş olamaz")
            .MaximumLength(1000).WithMessage("Kategori açıklaması en fazla 1000 karakter olmalıdır")
            .MinimumLength(10).WithMessage("Kategori açıklaması en az 10 karakter olmalıdır");
    }

    private async Task<bool> IsNameUniqueAsync(string name, CancellationToken cancellationToken) 
    {
        return !await _context.Categories.AnyAsync(c => c.Name.ToLower() == name.ToLower(), cancellationToken);
    }
}
