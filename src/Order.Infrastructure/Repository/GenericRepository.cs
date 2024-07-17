using Microsoft.EntityFrameworkCore;
using Order.Core.Entites;
using Order.Core.Interfaces;
using Order.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T Entity)
        {
           await _context.Set<T>().AddAsync(Entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var query =await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(query);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();
        

        public async Task<T> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);
        

        public async Task UpdateAsync(int id)
        {
            var query =await _context.Set<T>().FindAsync(id);
            _context.Update(query);
            await _context.SaveChangesAsync();
        }
    }
}
