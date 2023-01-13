using libraryApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace libraryApi.Infrastructure.Repository
{
    public class TypeRepository : IRepository<TypeLivre> 
    {
        private DbConnector _context;
        public TypeRepository(DbConnector context)
        {
            _context = context;
        }

        public async Task<TypeLivre> CreateAsync(TypeLivre entity)
        {
            await _context.Set<TypeLivre>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

   
        public async Task<IReadOnlyCollection<TypeLivre>> GetAllAsync()
        {
            var itmes = await _context.Set<TypeLivre>().ToListAsync();
            return itmes;
        }

        public async Task<TypeLivre> GetAsync(Guid id)
        {
            var item = await _context.Set<TypeLivre>().FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public async Task RemoveAsync(Guid id)
        {
            var item = await _context.Set<TypeLivre>().FirstOrDefaultAsync(i => i.Id == id);
            _context.Set<TypeLivre>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TypeLivre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

   
    }
}
