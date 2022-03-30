using kcms_challenge_dev_backend.InputModels;
using kcms_challenge_dev_backend.Models.Collections;
using kcms_challenge_dev_backend.Repositories.Interfaces;
using kcms_challenge_dev_backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository,
                              ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> CreateAsync(ProductInputModel ProductInputModel)
        {
            var category = await _categoryRepository.GetByCategoryIDAsync(ProductInputModel.CategoryID);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            Product product = new()
            {
                Description = ProductInputModel.Description,
                CategoryID = ProductInputModel.CategoryID
            };

            var result = await _productRepository.CreateAsync(product);

            return result;
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(string CategoryID)
        {
            var category = await _categoryRepository.GetByCategoryIDAsync(CategoryID);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            var result = await _productRepository.GetProductsByCategoryIDAsync(category.CategoryID);

            return result;
        }

        public Task<Product> GetByIdAsync(string ProductID)
        {
            return _productRepository.GetByIdAsync(ProductID);
        }
        public Task DeleteAsync(string ProductID)
        {
            return _productRepository.DeleteAsync(ProductID);
        }

        public Task UpdateAsync(string ProductID, string NewCategoryID)
        {
            Product product = new()
            {
                CategoryID = NewCategoryID
            };

            return _productRepository.UpdateAsync(ProductID, product);
        }
    }
}
