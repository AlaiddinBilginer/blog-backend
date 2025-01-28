using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Application.Common.Models.Pagination;

public sealed record PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; }
    public int PageNumber { get; }
    public int PageSize { get; set; }
    public int TotalCount { get; }
    public int TotalPages { get; }

    public PaginatedList(IEnumerable<T> items, int pageNumber, int pageSize, int totalCount)
    {
        Items = items.ToList().AsReadOnly();

        PageNumber = pageNumber;

        PageSize = pageSize;

        TotalCount = totalCount;

        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }

    [JsonConstructor]
    public PaginatedList(IReadOnlyCollection<T> items, int pageNumber, int pageSize, int totalCount)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }

    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize) 
    {
        var totalCount = await source.CountAsync();

        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedList<T>(items, pageNumber, pageSize, totalCount);
    }

    public static PaginatedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize) 
    {
        var totalCount = source.Count();

        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PaginatedList<T>(items, pageNumber, pageSize, totalCount);
    }

    public static PaginatedList<T> Create(List<T> source, int totalCount, int pageNumber, int pageSize) 
    {
        return new PaginatedList<T>(source, pageNumber, pageSize, totalCount);
    }
}
