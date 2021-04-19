using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Persistence.Contexts;
using SuperMarket.API.Domain.Persistence.Repositories;

namespace SuperMarket.API.Persistence.Repositories
{
    public class ProductTagRepository : BaseRepository , IProductTagRepository
    {
        public ProductTagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductTag>> ListAsync()
        {
            return await _context.ProductTags.Include(pt => pt.Product)
                .Include(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductTag>> ListByProductId(int productId)
        {
            return await _context.ProductTags.Where(pt => pt.ProductId == productId).Include(pt => pt.Product)
                .Include(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductTag>> ListByTagId(int tagId)
        {
            return await _context.ProductTags.Where(tg => tg.TagId == tagId)
                .Include(p => p.Product)
                .Include(t => t.Tag)
                .ToListAsync();
        }

        public async Task<ProductTag> FindByProductIdAndTagId(int productId, int tagId)
        {
            return await _context.ProductTags.FindAsync(productId, tagId);
        }

        public async Task addSync(ProductTag productTag)
        {
            await _context.ProductTags.AddAsync(productTag);
        }

        public void remove(ProductTag productTag)
        {
            _context.ProductTags.Remove(productTag);
        }

        public async Task AssingProductTag(int productId, int tagId)
        {
            ProductTag productTag;
            productTag = await FindByProductIdAndTagId(productId, tagId);
            if (productTag == null)
            {
                productTag = new ProductTag {ProductId = productId, TagId = tagId};
                await addSync(productTag);
            }
        }

        public async Task UnassingProductTag(int productId, int tagId)
        {
            ProductTag productTag = await FindByProductIdAndTagId(productId, tagId);
            if (productTag != null)
            {
                remove(productTag);
            }
        }
    }
}