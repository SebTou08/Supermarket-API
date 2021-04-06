using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Services.Communications;

namespace SuperMarket.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> GetByIdASync(int id);
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}