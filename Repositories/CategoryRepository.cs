using kcms_challenge_dev_backend.Models;
using kcms_challenge_dev_backend.Models.Collections;
using kcms_challenge_dev_backend.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _collection;
        private readonly MongoDBConfiguration _mongoDB;

        public CategoryRepository(MongoDBConfiguration mongoDB)
        {
            _mongoDB = mongoDB;
            _collection = _mongoDB.DB.GetCollection<Category>(nameof(Category)); // dynamically setting collection name
        }

        public async Task<Category> CreateAsync(Category Category)
        {
            await _collection.InsertOneAsync(Category);
            return Category;
        }

        public Task<Category> GetByCategoryIDAsync(string CategoryID)
        {
            var filter = Builders<Category>.Filter.Eq(f => f.CategoryID, CategoryID);
            var result = _collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public Task DeleteAsync(string CategoryID)
        {
            var result = _collection.DeleteOneAsync(d => d.CategoryID == CategoryID);
            return result;
        }

        public Task UpdateAsync(string CategoryID, Category Category)
        {
            var result = _collection.UpdateOneAsync(f => f.CategoryID == CategoryID, Builders<Category>.Update.Set("Name", Category.Name));
            return result;
        }

    }
}
