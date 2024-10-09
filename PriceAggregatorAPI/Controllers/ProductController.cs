using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PricAggregatorAPI.Models.DTOs;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;
using PriceAggregatorAPI;
using System.Net;

namespace PricAggregatorAPI.Controllers
{
    [ApiController]
    [Route("api/ProductAPI")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private APIResponse _response;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMapper mapper, IProductRepository repository, ILogger<ProductController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _response = new();
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAllProducts()
        {
            IEnumerable<Product> products = await _repository.GetAllProducts();

            if (products == null || products.Count() == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Result = _mapper.Map<List<ProductDTO>>(products);
            _response.StatusCode = HttpStatusCode.OK;
            
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProduct(int id)
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            Product product = await _repository.GetAsync(u => u.Id == id);

            if (product == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Result = _mapper.Map<ProductDTO>(product);
            _response.StatusCode = HttpStatusCode.OK;

            return _response;
        }

    }
}
