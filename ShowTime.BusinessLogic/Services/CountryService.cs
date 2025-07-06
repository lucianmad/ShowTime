using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class CountryService : GenericEntityService<Country, CountryGetDto, CountryCreateDto>, ICountryService
{
    private readonly ICountryRepository _countryRepository;
    protected override string EntityName => "Country";
    
    public CountryService(ICountryRepository countryRepository) : base(countryRepository)
    {
        _countryRepository = countryRepository;
    }
    
    protected override CountryGetDto MapToGetDto(Country country)
    {
        return new CountryGetDto
        {
            Id = country.Id,
            Name = country.Name
        };
    }
    
    protected override Country MapToEntityForCreate(CountryCreateDto countryCreateDto)
    {
        return new Country
        {
            Name = countryCreateDto.Name
        };   
    }

    protected override Country MapToEntityForUpdate(CountryCreateDto createDto, int id)
    {
        return new Country
        {
            Id = id,
            Name = createDto.Name
        };
    }
}