using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface ICityService : IEntityService<CityGetDto, CityCreateDto>
{
}