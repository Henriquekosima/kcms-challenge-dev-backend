using kcms_challenge_dev_backend.Models.Collections;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product Product);
        Task<List<Product>> GetProductsByCategoryIDAsync(string CategoryID);
        Task<Product> GetByIdAsync(string ProductID);
        Task DeleteAsync(string ProductID);
        Task UpdateAsync(string ProductID, Product Product);
    }
}
