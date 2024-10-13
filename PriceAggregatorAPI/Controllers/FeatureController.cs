using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;
using PriceAggregatorAPI.Models.DTOs;
using PriceAggregatorAPI.Models.Requests;

namespace PriceAggregatorAPI.Controllers;

[ApiController]
[Route("api/FeatureApi")]
public class FeatureController(
    IMapper mapper,
    IFeatureRepository repository,
    ILogger<FeatureController> logger) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IFeatureRepository _repository = repository;
    private readonly ILogger<FeatureController> _logger = logger;

    [HttpGet]
    public async Task<ActionResult<ApiResponse>> GetAllFeatures()
    {
        try
        {
            var features = await _repository.GetAllFeatures();
        
            if (features == null || !features.Any())
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = ["Unable to create feature. Product not found."]
                });
            }

            var featuresDto = _mapper.Map<ICollection<FeatureDto>>(features);
            
            return Ok(new ApiResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Result = featuresDto
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching features");

            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = [ex.Message]
            });
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<ApiResponse>> AddFeature([FromBody] AddFeatureRequest request)
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
            var feature = await _repository.AddFeature(request.ProductIds, request.Name);
            
            if (feature == null)
            {
                return NotFound(new ApiResponse()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = ["Unable to create feature. Product not found."]
                });
            }
            
            var featureDto = _mapper.Map<FeatureDto>(feature);

            return CreatedAtAction(nameof(GetFeature), new {id = feature.Id}, new ApiResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.Created,        
                Result = featureDto
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching features");

            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = [ex.Message]
            });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteFeature(int id) 
    {
        try
        {
            var isDeleted = await _repository.DeleteFeature(id);
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
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse>> GetFeature(int id)
    {
        try
        {
            var feature = await _repository.GetFeatureById(id);
        
            if (feature == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = new List<string> { "Feature not found." }
                });
            }

            var featureDto = _mapper.Map<FeatureDto>(feature);
        
            return Ok(new ApiResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Result = featureDto
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = new List<string> { ex.Message }
            });
        }
    }
}