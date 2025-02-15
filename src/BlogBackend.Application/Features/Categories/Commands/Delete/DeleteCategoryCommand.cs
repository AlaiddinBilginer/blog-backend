using BlogBackend.Application.Common.Models.Responses;
using MediatR;

namespace BlogBackend.Application.Features.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(Guid Id) : IRequest<ResponseDto<Guid>>;
