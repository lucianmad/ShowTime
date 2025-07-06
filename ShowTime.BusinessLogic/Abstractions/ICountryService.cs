using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface ICountryService : IEntityService<CountryGetDto, CountryCreateDto>
{
}