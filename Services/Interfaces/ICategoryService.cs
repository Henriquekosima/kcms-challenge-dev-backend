using kcms_challenge_dev_backend.InputModels;
using kcms_challenge_dev_backend.Models.Collections;
using kcms_challenge_dev_backend.ViewModels;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(CategoryInputModel CategoryInputModel);
        Task<Category> GetByIDAsync(string CategoryID);
        Task DeleteAsync(string CategoryID);
        Task UpdateAsync(string CategoryID, CategoryInputModel categoryInputModel);
    }
}
