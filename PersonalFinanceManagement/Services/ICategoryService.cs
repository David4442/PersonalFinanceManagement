using PersonalFinanceManagement.Database.Entities;
using PersonalFinanceManagement.Models;

namespace PersonalFinanceManagement.Services
{
    public interface ICategoryService
    {
        Task ImportCategories(IFormFile file);
        Task UploadToDb(IFormFile file);
        Task<TrPagedList<CategoryEntity>> GetCategories(string parentid, int page = 1, int pageSize = 5, string sortBy = null, SortOrderEnum sortOrder = SortOrderEnum.AscEnum);
    }
}
