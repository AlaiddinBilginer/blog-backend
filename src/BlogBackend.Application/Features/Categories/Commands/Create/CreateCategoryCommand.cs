using BlogBackend.Application.Common.Models.Responses;
using MediatR;

namespace BlogBackend.Application.Features.Categories.Commands.Create;

public sealed record CreateCategoryCommand (string Name, string Description, bool IsFeatured) : IRequest<ResponseDto<Guid>>;
