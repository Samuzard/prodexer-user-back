using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PriceAggregator.Core.IRepository;
using PriceAggregatorAPI.Models.DTOs;

namespace PriceAggregatorAPI.Controllers;

[ApiController]
[Route("api/Category")]
public class CategoryController(ICategoryRepository repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllCategories()
    {
        var categories = await  repository.GetCategories();

        if (categories == null || !categories.Any())
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Unable to create feature. Product not found."]
            });
        }
        
        return Ok(new ApiResponse
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            Result = mapper.Map<IEnumerable<CategoryDto>>(categories)
        });
    }
}