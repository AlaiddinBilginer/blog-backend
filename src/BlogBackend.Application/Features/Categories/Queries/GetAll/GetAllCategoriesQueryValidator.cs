﻿using FluentValidation;

namespace BlogBackend.Application.Features.Categories.Queries.GetAll;

public sealed class GetAllCategoriesQueryValidator : AbstractValidator<GetAllCategoriesQuery>
{
    public GetAllCategoriesQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Sayfa numarası 1'den küçük olamaz");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Sayfa boyutu 1'den küçük olamaz");
    }
}
