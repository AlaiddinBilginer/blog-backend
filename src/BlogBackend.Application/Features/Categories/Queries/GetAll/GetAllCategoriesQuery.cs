using BlogBackend.Application.Common.Models.Pagination;
using MediatR;

namespace BlogBackend.Application.Features.Categories.Queries.GetAll;

public sealed record GetAllCategoriesQuery(int PageNumber, int PageSize) : IRequest<PaginatedList<GetAllCategoriesDto>>;