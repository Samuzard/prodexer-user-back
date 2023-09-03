using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PricAggregatorAPI.Utils;
using PriceAggregator.Models;
using PriceAggregator.Models.DTOs;
using PriceAggregatorWeb.Services.IServices;
using System.Diagnostics;

namespace PriceAggregator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDTO> products = new();

            var response = await _productService.GetAllAsync();

            if (response != null && response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }

            if (response == null)
                return Redirect("/Home/Error/{0}");

            //products = _mapper.Map<ProductDTO>(products);

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Home/Error/{0}")]
        public IActionResult Error(int code)
        {
            return View(new ErrorViewModel { RequestId = "Test", ErrorMessage = $"Error occured with code {code}" });
        }
    }
}