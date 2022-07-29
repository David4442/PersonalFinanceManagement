using AutoMapper;
using PersonalFinanceManagement.Database.Entities;
using PersonalFinanceManagement.Database.Repository;
using PersonalFinanceManagement.Models;

namespace PersonalFinanceManagement.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;


        public CategoryService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }
        public async Task ImportCategories(IFormFile file)
        {
            var fileextension = Path.GetExtension(file.FileName);


            _categoriesRepository.UploadToDb(file);

            // return fileextension;


        }



        public async Task UploadToDb(IFormFile file)
        {
            _categoriesRepository.UploadToDb(file);
        }
        public async Task<TrPagedList<CategoryEntity>> GetCategories(string productid, int page = 1, int pageSize = 10, string sortBy = null, SortOrderEnum sortOrder = SortOrderEnum.AscEnum)
        {
            var result = await _categoriesRepository.List(productid, page, pageSize, sortBy, sortOrder);

            return result;
        }
    }
}
