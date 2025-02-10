using BlogBackend.Application.Common.Models.Pagination;
using BlogBackend.Application.Features.Categories.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BlogBackend.WebApi.Controllers.OData;

[Route("odata/categories")]
[ApiController]
[EnableQuery]
public class CategoriesController(ISender sender) : ODataController
{
    [HttpGet("getAllCategories")]
    public async Task<PaginatedList<GetAllCategoriesDto>> GetAllCategories(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetAllCategoriesQuery(pageNumber, pageSize), cancellationToken);
        return response;
    }
}
