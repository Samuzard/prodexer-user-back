using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PriceAggregator.Core.IRepository;
using PriceAggregatorAPI.Models.DTOs;
using PriceAggregatorAPI.Models.Requests;

namespace PriceAggregatorAPI.Controllers;

[ApiController]
[Route("api/FeatureApi")]
internal class FeatureController(
    IMapper mapper,
    IFeatureRepository repository,
    ILogger<FeatureController> logger) : ControllerBase
{
    [HttpGet]
    internal async Task<ActionResult<ApiResponse>> GetAllFeatures()
    {
        try
        {
            var features = await repository.GetFeatures();
        
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
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while fetching features");

            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = [ex.Message]
            });
        }
    }
    
    [HttpGet("{id:int}")]
    internal async Task<ActionResult<ApiResponse>> GetFeature(int id)
    {
        try
        {
            var feature = await repository.GetFeatures(f => f.Id == id);
        
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
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = [ex.Message]
            });
        }
    }
    
    [HttpPost]
    internal async Task<ActionResult<ApiResponse>> AddFeature([FromBody] AddFeatureRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ModelState.Values
                    .SelectMany(v => v.Errors
                        .Select(e => e.ErrorMessage))
                    .ToList()
            });
        }

        try
        {
            var feature = await repository.AddFeature(request.ProductIds, request.Name);
            
            if (feature == null)
            {
                return NotFound(new ApiResponse()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = ["Unable to create feature. Product not found."]
                });
            }
            
            var featureDto = mapper.Map<FeatureDto>(feature);

            return CreatedAtAction(nameof(GetFeature), new {id = feature.Id}, new ApiResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.Created,        
                Result = featureDto
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while fetching features");

            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = [ex.Message]
            });
        }
    }
    
    [HttpPut("{id:int}")]
    internal async Task<ActionResult<ApiResponse>> UpdateFeature(int id, [FromBody] UpdateFeatureRequest request)
    {
        try
        {
            var isDeleted = await repository.DeleteFeature(id);
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
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = [ex.Message]
            });
        }
    }
    
    [HttpDelete("{id:int}")]
    internal async Task<ActionResult<ApiResponse>> DeleteFeature(int id) 
    {
        try
        {
            var isDeleted = await repository.DeleteFeature(id);
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
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = [ex.Message]
            });
        }
    }
}