namespace ShowTime.BusinessLogic.Abstractions;

public interface IEntityService<TGetDto, TCreateDto>
{
    Task<TGetDto> GetEntityByIdAsync(int id);
    Task<IList<TGetDto>> GetAllEntitiesAsync();
    Task<TGetDto> AddEntityAsync(TCreateDto entity);
    Task UpdateEntityAsync(int id, TCreateDto entity);
    Task DeleteEntityAsync(int id);
}