using BlogBackend.Application.Common.Interfaces;
using BlogBackend.Application.Common.Models.Pagination;
using Dapper;
using MediatR;

namespace BlogBackend.Application.Features.Categories.Queries.GetAll;

public sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PaginatedList<GetAllCategoriesDto>>
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public GetAllCategoriesQueryHandler(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<PaginatedList<GetAllCategoriesDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var connection = _connectionFactory.CreateConnection();

        var offset = (request.PageNumber - 1) * request.PageSize;
        var pageSize = request.PageSize;

        var sql = @"
        SELECT COUNT(*) FROM ""categories"";

        SELECT ""id"", ""name"", ""description"", ""image_path"", ""is_featured""
        FROM ""categories""
        ORDER BY ""name""
        OFFSET @Offset LIMIT @PageSize;
    ";

        using var multi = await connection.QueryMultipleAsync(sql, new { Offset = offset, PageSize = pageSize });

        var totalCount = await multi.ReadSingleAsync<int>();

        var categories = (await multi.ReadAsync<GetAllCategoriesDto>()).ToList();

        return new PaginatedList<GetAllCategoriesDto>(categories, request.PageNumber, request.PageSize, totalCount);
    }
}
