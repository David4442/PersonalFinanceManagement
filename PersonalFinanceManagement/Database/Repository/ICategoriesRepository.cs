using PersonalFinanceManagement.Database.Entities;
using PersonalFinanceManagement.Models;

namespace PersonalFinanceManagement.Database.Repository
{
    public interface ICategoriesRepository
    {

        Task<TrPagedList<CategoryEntity>> List(string parentid, int page = 1, int pageSize = 5, string sortBy = null, SortOrderEnum sortOrder = SortOrderEnum.AscEnum);
        public Task ImportCategories(IFormFile file);
        public Task UploadToDb(IFormFile file);

    }
}

