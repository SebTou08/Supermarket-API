using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Services.Communications;

namespace SuperMarket.API.Domain.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task<IEnumerable<Tag>> ListByProductIdAsync(int productId);
        Task<TagResponse> GetById(int id);
        Task<TagResponse> SaveAsync(Tag tag);
        Task<TagResponse> UpdateAsync(int id, Tag tag);
        Task<TagResponse> DeleteAsync(int id);
    }
}