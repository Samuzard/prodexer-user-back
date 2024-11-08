using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PriceAggregator.Core.IRepository;
using System.Net;
using PriceAggregatorAPI.Models.DTOs;

namespace PriceAggregatorAPI.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController(
        IMapper mapper,
        IProductRepository repository,
        ILogger<ProductController> logger) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetAllProducts()
        {
            try
            {
                var products = await repository.GetProducts();

                if (products == null || !products.Any())
                {
                    return NotFound(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessages = ["Products not Found!"]
                    });
                }

                return Ok(new ApiResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = mapper.Map<List<ProductDto>>(products),
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

        [HttpGet("{id:long}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetProduct(long id)
        {
            try
            {
                var product = await repository.GetProducts(p => p.Id == id);

                if (product == null || !product.Any())
                {
                    return NotFound(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessages = ["Product is not Found!"]
                    });
                }

                return Ok(new ApiResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = mapper.Map<IEnumerable<ProductDto>>(product)
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
    }
}
