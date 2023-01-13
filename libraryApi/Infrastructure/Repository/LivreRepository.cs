using libraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace libraryApi.Infrastructure.Repository
{
    public class LivreRepository : IRepository<Livre> 
    {
        private DbConnector _context;
        public LivreRepository(DbConnector context)
        {
            _context = context;
        }

        public async Task<Livre> CreateAsync(Livre entity)
        {
            await _context.Set<Livre>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

   
        public async Task<IReadOnlyCollection<Livre>> GetAllAsync()
        {
            var itmes = await _context.Set<Livre>().ToListAsync();
            return itmes;
        }

        public async Task<Livre> GetAsync(Guid id)
        {
            var item = await _context.Set<Livre>().Include(l => l.Type).Include(l=> l.Auteur).FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public async Task RemoveAsync(Guid id)
        {
            var item = await _context.Set<Livre>().FirstOrDefaultAsync(i => i.Id == id);
            _context.Set<Livre>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Livre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

   
    }
}
