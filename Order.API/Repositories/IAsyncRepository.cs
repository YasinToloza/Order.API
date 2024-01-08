using Order.API.Models;

namespace Order.API.Repositories
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
