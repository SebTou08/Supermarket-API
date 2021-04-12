using System.Threading.Tasks;
using SuperMarket.API.Domain.Persistence.Contexts;
using SuperMarket.API.Domain.Persistence.Repositories;

namespace SuperMarket.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}