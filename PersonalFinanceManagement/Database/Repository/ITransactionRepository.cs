
using PagedList;
using PersonalFinanceManagement.Models;

namespace PersonalFinanceManagement.Repository
{
     public  interface  ITransactionRepository
    {
        Task<TrPagedList<Transaction>> List(string transactionKind, DateTime? startDate, DateTime? endDate,int page = 1, int pageSize = 5, string sortBy = null, SortOrderEnum sortOrder = SortOrderEnum.AscEnum);


        
        Task<Transaction> Get(string Id);

        Task<bool> Delete(string Id);
        IEnumerable<Transaction> GetAll(); 
        
        public Task ImportTransactions(IFormFile file);
        public Task UploadToDb(IFormFile file);

    }
}
