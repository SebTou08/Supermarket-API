using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Persistence.Contexts;
using SuperMarket.API.Domain.Persistence.Repositories;

namespace SuperMarket.API.Persistence.Repositories
{
    public class ProductRepository : BaseRepository , IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(prop => prop.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> ListByCategoryId(int categoryId)
        {
            return await _context.Products.Where(p=>p.CategoryId ==categoryId).Include(p=>p.Category).ToListAsync();
        }
    }
}