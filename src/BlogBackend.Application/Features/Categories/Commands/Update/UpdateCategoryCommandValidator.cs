using BlogBackend.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Application.Features.Categories.Commands.Update;

public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateCategoryCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olmalıdır")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır");

        RuleFor(x => x.Description)
            .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.Description)).WithMessage("Kategori açıklaması boş olamaz")
            .MaximumLength(1000).WithMessage("Kategori açıklaması en fazla 1000 karakter olmalıdır")
            .MinimumLength(10).WithMessage("Kategori açıklaması en az 10 karakter olmalıdır");
    }
}
