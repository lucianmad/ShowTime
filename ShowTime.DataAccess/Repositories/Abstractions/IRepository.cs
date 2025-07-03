namespace ShowTime.DataAccess.Repositories.Abstractions;

public interface IRepository<T> where T: class
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(int id);
    public Task AddAsync(T entity);
    public Task UpdateAsync(int id, T entity);
    public Task DeleteAsync(int id);
}