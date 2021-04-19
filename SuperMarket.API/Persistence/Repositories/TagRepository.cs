using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Persistence.Contexts;
using SuperMarket.API.Domain.Persistence.Repositories;

namespace SuperMarket.API.Persistence.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
        }

        public async Task<Tag> FindById(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
        }

        public void Remove(Tag tag)
        {
            _context.Tags.Remove(tag);
        }
    }
}