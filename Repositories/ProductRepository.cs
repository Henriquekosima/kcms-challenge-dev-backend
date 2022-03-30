using kcms_challenge_dev_backend.Models;
using kcms_challenge_dev_backend.Models.Collections;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Repositories.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;
        private readonly MongoDBConfiguration _mongoDB;

        public ProductRepository(MongoDBConfiguration mongoDB)
        {
            _mongoDB = mongoDB;
            _collection = _mongoDB.DB.GetCollection<Product>(nameof(Product)); // dynamically setting collection name
        }

        public async Task<Product> CreateAsync(Product Product)
        {
            await _collection.InsertOneAsync(Product);
            return Product;
        }

        public Task<List<Product>> GetProductsByCategoryIDAsync(string CategoryID)
        {
            var result = _collection.Find(c => c.CategoryID == CategoryID).ToListAsync();

            return result;
        }

        public Task<Product> GetByIdAsync(string ProductID)
        {
            var result = _collection.Find(c => c.ProductID == ProductID).FirstOrDefaultAsync();
            return result;
        }

        public Task DeleteAsync(string ProductID)
        {
            var result = _collection.DeleteOneAsync(d => d.ProductID == ProductID);
            return result;
        }

        public Task UpdateAsync(string ProductID, Product Product)
        {
            var result = _collection.UpdateOneAsync(u => u.ProductID == ProductID, Builders<Product>.Update.Set("CategoryID", Product.CategoryID));
            return result;
        }
    }
}
