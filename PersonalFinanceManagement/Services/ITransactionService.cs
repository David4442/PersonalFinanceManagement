using PagedList;
using PersonalFinanceManagement.Models;

namespace PersonalFinanceManagement.Services
{
    public interface ITransactionService
    {
        Task<TrPagedList<Transaction>> GetTransactions(string transactionKind, DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 10, string sortBy = null, SortOrderEnum sortOrder = SortOrderEnum.AscEnum);
        Task<Models.Transaction> GetTransaction(string TransactionId);
       
        Task<bool> DeleteTransaction(string TransactionId);
        Task ImportTransactions(IFormFile file);
        Task UploadToDb(IFormFile file);
    }
}
