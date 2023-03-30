using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
       
        public ProductsController(IProductService productService = null)
        {
            _productService = productService;
        }


        public async Task<IActionResult> Index()
        {
            var CustomResponse = await _productService.GetProductsWithCategory();
            return View( CustomResponse.Data);
        }
    }
}
