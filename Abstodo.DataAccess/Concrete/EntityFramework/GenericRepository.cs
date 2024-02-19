using Abstodo.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EfAbstodoContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(EfAbstodoContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(object Id)
        {
            return await _dbSet.FindAsync(Id);
        }
        public async Task InsertAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
            await SaveAsync();
        }
        public async Task UpdateAsync(T Entity)
        {
            _dbSet.Update(Entity);
            await SaveAsync();
        }
        public async Task DeleteAsync(object Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
