using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Services.Communications;

namespace SuperMarket.API.Domain.Services
{
    public interface IProductTagServices
    {
        Task<IEnumerable<ProductTag>> ListAsync();
        Task<ICollection<ProductTag>> ListByProductIdAsync(int productId);
        Task<IEnumerable<ProductTag>> ListByTagAsync(int tagId);
        Task<ProductTagResponse> AssingProductTagAsync(int ptoductId, int tagId);
        Task<ProductTagResponse> UnassingProductTagAsync(int productId, int tagId);
    }
}