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

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> AddFeature([FromBody] AddFeatureRequest request)
    {
        if (!ModelState.IsValid)
        {
            var apiResponse = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ModelState.Values
                    .SelectMany(v => v.Errors
                        .Select(e => e.ErrorMessage))
                    .ToList()
            };

            return BadRequest(apiResponse);
        }

        try
        {
            var feature = await _repository.AddFeature(request.ProductIds, request.Name);
            
            if (feature == null)
            {
                var apiResponse = new ApiResponse()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = ["Unable to create feature. Product not found."]
                };

                return NotFound(apiResponse);
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
             var apiResponse = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = ["An error occurred while processing your request."]
            };

            return StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse>> GetFeature(int id)
    {
        throw new NotImplementedException();
    }
}