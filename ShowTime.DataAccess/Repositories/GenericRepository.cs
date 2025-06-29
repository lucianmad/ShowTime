using Microsoft.EntityFrameworkCore;

namespace ShowTime.DataAccess.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ShowTimeDbContext context)
    {
        _dbSet = context.Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<T?> GetByIdAsync(int id)
    {
        try
        {
            return await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve entity with id {id}: {ex.Message}");
        }
    }
    public async Task AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to add entity: {ex.Message}");
        }
    }

    public async Task UpdateAsync(int id, T entity)
    {
        try
        {
            var entry = await _dbSet.FindAsync(id);
            if (entry == null)
            {
                throw new Exception($"Entity with id {id} not found.");
            }
            _dbSet.Update(entity);   
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to update entity with id {id}: {ex.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"Entity with id {id} not found.");       
            }
            _dbSet.Remove(entity);   
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to delete entity with id {id}: {ex.Message}");
        }
    }
}