using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using PersonalFinanceManagement.Database;
using PersonalFinanceManagement.Models;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagement.Repository;
using PersonalFinanceManagement.Services;
using CsvHelper;
using CsvHelper;
using System.Globalization;
using PersonalFinanceManagement.Mappings;
using CsvHelper.Configuration;
using System.Text.RegularExpressions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionsController> _logger;
        private readonly TransactionsDbContext _context;

        public TransactionsController(ITransactionService transactionService, ILogger<TransactionsController> logger, TransactionsDbContext context)
        {
            _transactionService = transactionService;
            _logger = logger;
            _context = context;
        }
        [HttpPost]

        [Route("import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadData(IFormFile file)
        {
            var result = _transactionService.ImportTransactions(file);
            if (result == null)
            {
                return BadRequest();
            }
            else

            return Ok();
        }
        [HttpGet]
        [Route("transactions")]
        public async Task<IActionResult> GetProducts([FromQuery] string transactionKind, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrderEnum sortOrder)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            _logger.LogInformation("Returning {page}. page of products", page);
            var result = await _transactionService.GetTransactions(transactionKind,startDate.Value,endDate.Value,page.Value, pageSize.Value, sortBy, sortOrder);
            return Ok(result);
        }


    }

}
    
