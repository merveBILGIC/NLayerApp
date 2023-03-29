using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategortiesController : CustomBaseController
    {

        private readonly ICategoryService _categoryService;

        public CategortiesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCetegortyByIdWithProductAsync(int categortyId)
        {
            return CreateAcctionResult(await _categoryService.GetSingleCetegortyByIdWithProductAsync(categortyId));
        }

    }
}
