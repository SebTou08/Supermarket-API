using System.Threading.Tasks;

namespace SuperMarket.API.Domain.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        
    }
}