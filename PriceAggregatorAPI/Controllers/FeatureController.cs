using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PriceAggregator.Core.IRepository;
using PriceAggregatorAPI;
using PriceAggregatorAPI.Models.Requests;

namespace PricAggregatorAPI.Controllers;

[ApiController]
[Route("api/FeatureApi")]
public class FeatureController(
    IMapper mapper,
    IFeatureRepository repository,
    ILogger<FeatureController> logger) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IFeatureRepository _repository = repository;
    private readonly ApiResponse _response = new();
    private readonly ILogger<FeatureController> _logger = logger;

    [HttpGet]
    public async Task<ActionResult<ApiResponse>> GetAllFeatures()
    {
        try
        {
            var results = await _repository.GetAllFeatures();
        
            if (results == null || !results.Any())
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
                Result = results
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

            return CreatedAtAction(nameof(GetFeature), new {id = feature.Id}, new ApiResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Result = feature
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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse>> GetFeature(int id)
    {
        throw new NotImplementedException();
    }
}