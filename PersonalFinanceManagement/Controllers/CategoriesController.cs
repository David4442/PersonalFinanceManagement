using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceManagement.Database;
using PersonalFinanceManagement.Models;
using PersonalFinanceManagement.Services;

namespace PersonalFinanceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger;
        private readonly TransactionsDbContext _context;
       

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger, TransactionsDbContext context)
        {
            _categoryService = categoryService;
            _logger = logger;
            _context = context;
           
        }
        [HttpPost]

        [Route("import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadCategories(IFormFile file)
        {
            var result = _categoryService.ImportCategories(file);
            if (result == null)
            {
                return BadRequest();
            }
            else

                return Ok();
        }
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories([FromQuery] string productid, [FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrderEnum sortOrder)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            _logger.LogInformation("Returning {page}. page of products", page);
            var result = await _categoryService.GetCategories(productid, page.Value, pageSize.Value, sortBy, sortOrder);
            return Ok(result);
        }


    }
}
