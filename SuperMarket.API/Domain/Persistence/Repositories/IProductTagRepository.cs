using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;

namespace SuperMarket.API.Domain.Persistence.Repositories
{
    public interface IProductTagRepository
    {
        Task<IEnumerable<ProductTag>> ListAsync();
        Task<IEnumerable<ProductTag>> ListByProductId(int productId);
        Task<IEnumerable<ProductTag>> ListByTagId(int tagId);
        Task<ProductTag> FindByProductIdAndTagId(int productId, int tagId);
        Task addSync(ProductTag productTag);
        void remove(ProductTag productTag);
        Task AssingProductTag(int productId, int tagId);
        Task UnassingProductTag(int productId, int tagId);

    }
}