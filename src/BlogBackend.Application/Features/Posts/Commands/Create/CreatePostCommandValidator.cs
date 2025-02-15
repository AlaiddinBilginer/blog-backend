using BlogBackend.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Application.Features.Posts.Commands.Create;

public sealed class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    private readonly IApplicationDbContext _context;
    public CreatePostCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık boş olamaz.")
            .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş olamaz.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter içermelidir.")
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter içermelidir.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("İçerik boş olamaz.");

        RuleFor(x => x.Slug)
            .NotEmpty().WithMessage("Slug boş olamaz.")
            .MinimumLength(3).WithMessage("Slug en az 3 karakter içermelidir.")
            .MustAsync(IsSlugUniqueAsync).WithMessage("Bu slug zaten kullanılmaktadır.");

        RuleFor(x => x.ReadingTimeInMinutes)
            .GreaterThanOrEqualTo(1).WithMessage("Okuma süresi en az 1 dakika olmalıdır.");
    }

    private async Task<bool> IsSlugUniqueAsync(string slug, CancellationToken cancellationToken)
    {
        return !await _context.Posts.AnyAsync(p => p.Slug.ToLower() == slug.ToLower(), cancellationToken);
    }
}

