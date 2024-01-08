using Microsoft.EntityFrameworkCore;
using Order.API.Data;
using Order.API.Models;

namespace Order.API.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext dbContext;
        public RepositoryBase(AppDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
