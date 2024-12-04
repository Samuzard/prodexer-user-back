using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PriceAggregator.Core.IRepository;
using PriceAggregatorAPI.Models.DTOs;
using PriceAggregatorAPI.Models.Requests;
using PriceAggregatorAPI.Utils;

namespace PriceAggregatorAPI.Controllers;

[ApiController]
[Route("api/FeaturedItem")]
public class FeaturedItemController(
    IMapper mapper,
    IFeaturedItemRepository featuredItemRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse>> GetAllFeaturedItems()
    {
        var featuredItems = await featuredItemRepository.GetFeaturedItems();

        if (featuredItems == null || !featuredItems.Any())
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Unable to create featured item. Product not found."]
            });
        }

        var dto = mapper.Map<FeaturedItemContainerDto>(featuredItems);
        
        return Ok(new ApiResponse
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            Result = dto
        });
    }

    [HttpGet("{featuredItemId:long}")]
    public async Task<ActionResult<ApiResponse>> GetFeaturedItem(long featuredItemId)
    {
        var featuredItem = await featuredItemRepository.GetFeaturedItems(f => f.Id == featuredItemId);

        if (featuredItem == null || !featuredItem.Any())
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Featured item not found."]
            });
        }

        return Ok(new ApiResponse
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            Result = mapper.Map<IEnumerable<FeaturedItemDto>>(featuredItem)
        });
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> AddFeaturedItem([FromBody] FeaturedItemRequest request)
    {
        var isValid = FeaturedItemHelper.ValidateRequest(ModelState, out var errorMessages,
            (name) => !string.IsNullOrEmpty(name), request?.Name);

        if (!isValid)
        {
            return BadRequest(new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = errorMessages
            });
        }

        var featuredItem = await featuredItemRepository.AddFeaturedProducts(request?.ProductIds, request?.Name);

        if (featuredItem == null)
        {
            return NotFound(new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Unable to create featured item. Product not found."]
            });
        }

        return CreatedAtAction(nameof(GetFeaturedItem), new { featuredItemId = featuredItem.Id }, new ApiResponse
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.Created,
            Result = mapper.Map<FeaturedItemDto>(featuredItem)
        });
    }

    [HttpPut("{featuredItemId:long}")]
    public async Task<ActionResult<ApiResponse>> UpdateFeaturedItem(long featuredItemId, [FromBody] FeaturedItemRequest request)
    {
        var isValid = FeaturedItemHelper.ValidateRequest(ModelState, out var errorMessages,
            (productIds) => productIds?.Length > 0, request?.ProductIds);

        if (!isValid)
        {
            return BadRequest(new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = errorMessages
            });
        }

        var featuredItem = await featuredItemRepository.UpdateFeaturedProduct(featuredItemId, request?.Name, request?.ProductIds);

        if (featuredItem == null)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Unable to delete featured item. Not found."]
            });
        }

        return Ok(new ApiResponse
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            Result = mapper.Map<FeaturedItemDto>(featuredItem)
        });
    }

    [HttpDelete("{featuredItemId:long}")]
    public async Task<ActionResult<ApiResponse>> DeleteFeaturedItem(long featuredItemId)
    {
        var isDeleted = await featuredItemRepository.DeleteFeaturedItem(featuredItemId);
        if (!isDeleted)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Unable to delete featured item. Not found."]
            });
        }

        return NoContent();
    }
}