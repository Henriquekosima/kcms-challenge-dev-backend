using kcms_challenge_dev_backend.InputModels;
using kcms_challenge_dev_backend.Models.Collections;
using kcms_challenge_dev_backend.Repositories.Interfaces;
using kcms_challenge_dev_backend.Services.Interfaces;
using kcms_challenge_dev_backend.ViewModels;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> CreateAsync(CategoryInputModel CategoryInputModel)
        {
            Category category = new()
            {
                Name = CategoryInputModel.Name
            };

            return _categoryRepository.CreateAsync(category);
        }

        public Task<Category> GetByIDAsync(string CategoryID)
        {
            return _categoryRepository.GetByCategoryIDAsync(CategoryID);
        }
        public Task DeleteAsync(string CategoryID)
        {
            return _categoryRepository.DeleteAsync(CategoryID);
        }

        public Task UpdateAsync(string CategoryID, CategoryInputModel CategoryInputModel)
        {
            Category category = new()
            {
                Name = CategoryInputModel.Name
            };

            return _categoryRepository.UpdateAsync(CategoryID, category);
        }
    }
}
