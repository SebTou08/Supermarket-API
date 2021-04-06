using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Services.Communications;

namespace SuperMarket.API.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> ListByTagIdAsync(int tagId);
        Task<ProductTagResponse> GetByIdAsync(int id);

    }
}