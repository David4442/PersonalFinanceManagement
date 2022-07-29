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
using PersonalFinanceManagement.Database.Repository;

namespace PersonalFinanceManagement.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly TransactionsDbContext _context;
        
        public CategoriesRepository(TransactionsDbContext dbContext)
        {
            _context = dbContext;
           
        }

       
        public async Task ImportCategories(IFormFile file)
        {
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Path.GetFileName(file.FileName);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), filename);
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

                csv.Context.RegisterClassMap<CategoriesMap>();
                

                var records = csv.GetRecords<CategoryEntity>().ToList();
                List<CategoryEntity> items = new List<CategoryEntity>();
                foreach (var record in records)
                {

                    /* if (string.IsNullOrWhiteSpace(record.id))
                     {
                         break;
                     }*/
                    if (record.ParentCode == "")
                    {
                        CategoryEntity category;
                        category = _context.Categories.Where(s => s.Code == record.Code).FirstOrDefault();
                        if(category == null)
                        {
                            category = new CategoryEntity();
                        }
                       
                        category.Code = record.Code;
                        category.Name = record.Name;

                        
                        items.Add(category);
                        
                        var index = items.FindIndex(x => x.Code == record.Code); 
                        items.RemoveAt(index);
                        if (items.Count == index)
                        {
                            items.Add(category);
                        }  
                    }
                    else
                    {
                        CategoryEntity subCategory;
                        subCategory = _context.Categories.Where(s => s.Code == record.Code).FirstOrDefault();

                        if (subCategory == null)
                        {
                            subCategory = new CategoryEntity();
                        }

                        subCategory.Code = record.Code;
                        subCategory.Name = record.Name;
                        subCategory.ParentCode = record.ParentCode;

                        if (!_context.Categories.Any(x => x.Code.Equals(record.Code)))
                            _context.Categories.Add(subCategory);
                        else
                            _context.Categories.Update(subCategory);
                    }
                    
                }
                //Vnesuvanje vo baza
                foreach (CategoryEntity item in items)
                {
                    if (!_context.Categories.Any(c => c.Code.Equals(item.Code)))
                        _context.Categories.Add(item);




                    else
                        _context.Categories.Update(item);

                }
                _context.SaveChanges();
                
            }
        }
        public async Task<TrPagedList<CategoryEntity>> List(string parentid, int page = 1, int pageSize = 5, string sortBy = null, SortOrderEnum sortOrder = SortOrderEnum.AscEnum)
        {
            var query = _context.Categories.AsQueryable();

            var TotalCount = query.Count();

            var totalPages = (int)Math.Ceiling(TotalCount * 1.0 / pageSize);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "parentcode":
                        query = sortOrder == SortOrderEnum.AscEnum ? query.OrderBy(x => x.ParentCode) : query.OrderByDescending(x => x.ParentCode);
                        break;
                    case "Code":
                        query = sortOrder == SortOrderEnum.AscEnum ? query.OrderBy(x => x.Code) : query.OrderByDescending(x => x.Code);
                        break;
                   
                   
                }
            }
            else
            {
                query = query.OrderBy(p => p.Code);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            return new TrPagedList<CategoryEntity>
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







