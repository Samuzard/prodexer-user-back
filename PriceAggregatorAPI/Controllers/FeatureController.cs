using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PriceAggregator.Core.IRepository;
using PriceAggregatorAPI.Models.DTOs;
using PriceAggregatorAPI.Models.Requests;
using PriceAggregatorAPI.Utils;

namespace PriceAggregatorAPI.Controllers;

[ApiController]
[Route("api/Feature")]
public class FeatureController(
    IMapper mapper,
    IFeatureRepository featureRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse>> GetAllFeatures()
    {
        var features = await featureRepository.GetFeatures();

        if (features == null || !features.Any())
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
            Result = mapper.Map<IEnumerable<FeatureDto>>(features)
        });
    }

    [HttpGet("{featureId:int}")]
    public async Task<ActionResult<ApiResponse>> GetFeature(int featureId)
    {
        var feature = await featureRepository.GetFeatures(f => f.Id == featureId);

        if (feature == null || !feature.Any())
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Feature not found."]
            });
        }

        return Ok(new ApiResponse
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            Result = mapper.Map<IEnumerable<FeatureDto>>(feature)
        });
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> AddFeature([FromBody] FeatureRequest request)
    {
        var isValid = FeatureHelper.ValidateRequest(ModelState, out var errorMessages,
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

        var feature = await featureRepository.AddFeatureWithProducts(request?.ProductIds, request?.Name);

        if (feature == null)
        {
            return NotFound(new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Unable to create feature. Product not found."]
            });
        }

        return CreatedAtAction(nameof(GetFeature), new { featureId = feature.Id }, new ApiResponse
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.Created,
            Result = mapper.Map<FeatureDto>(feature)
        });
    }

    [HttpPut("{featureId:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateFeature(int featureId, [FromBody] FeatureRequest request)
    {
        var isValid = FeatureHelper.ValidateRequest(ModelState, out var errorMessages,
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

        var feature = await featureRepository.UpdateFeatureWithProducts(featureId, request?.Name, request?.ProductIds);

        if (feature == null)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Unable to delete feature. Not found."]
            });
        }

        return Ok(new ApiResponse
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            Result = mapper.Map<FeatureDto>(feature)
        });
    }

    [HttpDelete("{featureId:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteFeature(int featureId)
    {
        var isDeleted = await featureRepository.DeleteFeature(featureId);
        if (!isDeleted)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Unable to delete feature. Not found."]
            });
        }

        return NoContent();
    }
}