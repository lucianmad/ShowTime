using ShowTime.BusinessLogic.Abstractions;
using ShowTime.DataAccess.Repositories;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public abstract class GenericEntityService<TEntity, TGetDto, TCreateDto> : IEntityService<TGetDto, TCreateDto> where TEntity : class
{
    private readonly IRepository<TEntity> _repository;
    protected abstract string EntityName { get; }
    
    public GenericEntityService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    protected abstract TGetDto MapToGetDto(TEntity entity);
    protected abstract TEntity MapToEntityForCreate(TCreateDto dto);
    protected abstract TEntity MapToEntityForUpdate(TCreateDto createDto, int id);

    public async Task<TGetDto> GetEntityByIdAsync(int id)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception($"{EntityName} with id {id} not found");
            }
            return MapToGetDto(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve {EntityName} with id {id}: {ex.Message}");
        }
    }

    public async Task<IList<TGetDto>> GetAllEntitiesAsync()
    {
        try
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToGetDto).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve all {EntityName}s: {ex.Message}");       
        }
    }

    public async Task<TGetDto> AddEntityAsync(TCreateDto entityCreateDto)
    {
        var entity = MapToEntityForCreate(entityCreateDto);
        try
        {
            var savedEntity = await _repository.AddAsync(entity);
            return MapToGetDto(savedEntity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to add {EntityName}: {ex.Message}");       
        }   
    }

    public async Task UpdateEntityAsync(int id, TCreateDto entityCreateDto)
    {
        try
        {
            var entity = MapToEntityForUpdate(entityCreateDto, id);
            await _repository.UpdateAsync(id, entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to update {EntityName} with id {id}: {ex.Message}");      
        }
    }

    public async Task DeleteEntityAsync(int id)
    {
        try
        {
            await _repository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to delete {EntityName} with id {id}: {ex.Message}");       
        }  
    }
}