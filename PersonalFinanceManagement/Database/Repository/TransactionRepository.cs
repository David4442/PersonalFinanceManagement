using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagement.Database;
using PersonalFinanceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Text.RegularExpressions;
using CsvHelper;
using PersonalFinanceManagement.Mappings;
using CsvHelper.Configuration;
using System.Globalization;
using PersonalFinanceManagement.Database.Entities;

namespace PersonalFinanceManagement.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionsDbContext _context;
        public TransactionRepository(TransactionsDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> Delete(string Id)
        {
            var transaction = await Get(Id);

            if (transaction == null)
            {
                return false;
            }

            _context.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Transaction> Get(string Id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.Id == Id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task ImportTransactions(IFormFile file)
            {
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Path.GetFileName(file.FileName);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Database", filename);
            UploadToDb(file);
          //  return filepath;

        }

        public async Task UploadToDb(IFormFile file)
        {

            var fileextension = Path.GetExtension(file.FileName);
            var filename = Path.GetFileName(file.FileName);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                IgnoreBlankLines = true,
                BadDataFound = null,

            };

            
                using (var reader = new StreamReader(filepath))
                using (var csv = new CsvReader(reader, config))

                {

                    csv.Context.RegisterClassMap<TransactionsMap>();

                    var records = csv.GetRecords<Transaction>().ToList();
                    foreach (var record in records)
                    {

                    /* if (string.IsNullOrWhiteSpace(record.id))
                     {
                         break;
                     }*/
                    Transaction transaction;
                        transaction = _context.Transactions.Where(s => s.Id == record.Id).FirstOrDefault();

                        if (transaction == null)
                        {
                            transaction = new Transaction();
                        }

                        transaction.Id = record.Id;
                        transaction.BeneficiaryName = record.BeneficiaryName;
                        transaction.Date = record.Date;
                        transaction.Direction = record.Direction;
                        transaction.Amount = record.Amount;
                        transaction.Description = record.Description;
                        transaction.Currency = record.Currency;
                        transaction.Mcc = record.Mcc;
                        transaction.Kind = record.Kind;

                        if (!_context.Transactions.Any(x => x.Id.Equals(record.Id)))
                             _context.Transactions.Add(transaction);
                        else
                            _context.Transactions.Update(transaction);
                    }
                    _context.SaveChanges();
                }
        }

          

        public async Task<TrPagedList<Transaction>> List(string transactionKind, DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 5, string sortBy = null, SortOrderEnum sortOrder = SortOrderEnum.AscEnum)
        {
            var query = _context.Transactions.AsQueryable();

            var TotalCount = query.Count();

            var totalPages = (int)Math.Ceiling(TotalCount * 1.0 / pageSize);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "id":
                        query = sortOrder == SortOrderEnum.AscEnum ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
                        break;
                    case "kind":
                        query = sortOrder == SortOrderEnum.AscEnum ? query.OrderBy(x => x.Kind) : query.OrderByDescending(x => x.Kind);
                        break;
                    default:
                    case "date":
                        query = sortOrder == SortOrderEnum.AscEnum ? query.OrderBy(x => x.Date) : query.OrderByDescending(x => x.Date);
                        break;
                }
            }
            else
            {
                query = query.OrderBy(p => p.Direction);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            return new TrPagedList<Transaction>      
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = TotalCount,
                TotalPages = totalPages,
                Items = items,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
        }
    }
}




            
            

