using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;

namespace SuperMarket.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        
    }
}