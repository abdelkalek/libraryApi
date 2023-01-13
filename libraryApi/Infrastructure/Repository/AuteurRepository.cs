using libraryApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace libraryApi.Infrastructure.Repository
{
    public class AuteurRepository : IRepository<Auteur> 
    {
        private DbConnector _context;
        public AuteurRepository(DbConnector context)
        {
            _context = context;
        }

        public async Task<Auteur> CreateAsync(Auteur entity)
        {
            await _context.Set<Auteur>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

   
        public async Task<IReadOnlyCollection<Auteur>> GetAllAsync()
        {
            var itmes = await _context.Set<Auteur>().ToListAsync();
            return itmes;
        }

        public async Task<Auteur> GetAsync(Guid id)
        {
            var item = await _context.Set<Auteur>().FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public async Task RemoveAsync(Guid id)
        {
            var item = await _context.Set<Auteur>().FirstOrDefaultAsync(i => i.Id == id);
            _context.Set<Auteur>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Auteur entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

   
    }
}
