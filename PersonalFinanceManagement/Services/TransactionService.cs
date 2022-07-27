using AutoMapper;
using PagedList;
using PersonalFinanceManagement.Models;
using PersonalFinanceManagement.Repository;

namespace PersonalFinanceManagement.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;


        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteTransaction(string TransactionId)
        {
            return await _transactionRepository.Delete(TransactionId);
        }

        public async Task<Transaction> GetTransaction(string TransactionId)
        {
            var transaction = await _transactionRepository.Get(TransactionId);

            if (transaction == null)
            {
                return null;
            }
            return _mapper.Map<Models.Transaction>(transaction);
        }
        public async Task ImportTransactions(IFormFile file )
        {
            var fileextension = Path.GetExtension(file.FileName);
            
                
                 _transactionRepository.UploadToDb(file);

          // return fileextension;
            
            
        }
          
        

      public async Task UploadToDb(IFormFile file)
        {
            _transactionRepository.UploadToDb(file);
        }



        public async Task<TrPagedList<Transaction>> GetTransactions(string transactionKind, DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 10, string sortBy = null, SortOrderEnum sortOrder = SortOrderEnum.AscEnum)
        {
            var result = await _transactionRepository.List(transactionKind,startDate,endDate,page, pageSize, sortBy, sortOrder);

            return result;
        }
    }
}
