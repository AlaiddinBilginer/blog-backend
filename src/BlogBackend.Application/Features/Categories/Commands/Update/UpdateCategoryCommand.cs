using BlogBackend.Application.Common.Models.Responses;
using MediatR;

namespace BlogBackend.Application.Features.Categories.Commands.Update;

public sealed record UpdateCategoryCommand (Guid Id, string Name, string Description, bool IsFeatured) : IRequest<ResponseDto<Guid>>;
