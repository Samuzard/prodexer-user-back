using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PriceAggregator.Models;
using PriceAggregator.Models.DTOs;
using PriceAggregatorWeb.Services.IServices;

namespace PriceAggregator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDTO> products;

            var response = await _productService.GetAllAsync();
            
            if (response == null)
            {
                return Redirect("/Home/Error/{0}");
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }

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