using kcms_challenge_dev_backend.Models.Collections;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category Category);
        Task<Category> GetByCategoryIDAsync(string CategoryID);
        Task DeleteAsync(string CategoryID);
        Task UpdateAsync(string CategoryID, Category Category);
    }
}
