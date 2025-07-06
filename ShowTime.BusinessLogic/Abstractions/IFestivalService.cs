using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IFestivalService : IEntityService<FestivalGetDto, FestivalCreateDto>
{
    Task<List<FestivalGetDto>> SearchByNameAsync(string name);
    Task<List<FestivalGetDto>> FilterByCityAsync(int cityId);
    Task<List<FestivalGetDto>> FilterByDateAsync(DateTime date);
    Task<List<FestivalGetDto>> FilterByCountryAsync(int countryId);   
}