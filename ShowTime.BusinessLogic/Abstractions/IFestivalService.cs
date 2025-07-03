using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IFestivalService : IEntityService<FestivalGetDto, FestivalCreateDto>
{
    Task<List<FestivalGetDto>> FilterByLocationAsync(int locationId);
    Task<List<FestivalGetDto>> FilterByDateAsync(DateTime date);   
    Task<List<FestivalGetDto>> SearchByNameAsync(string name);   
}