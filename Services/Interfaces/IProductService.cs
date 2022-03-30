using kcms_challenge_dev_backend.InputModels;
using kcms_challenge_dev_backend.Models.Collections;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(ProductInputModel ProductInputModel);
        Task<List<Product>> GetProductsByCategoryIdAsync(string CategoryID);
        Task<Product> GetByIdAsync(string ProductID);
        Task DeleteAsync(string ProductID);
        Task UpdateAsync(string ProductID, string NewCategoryID);
    }
}
