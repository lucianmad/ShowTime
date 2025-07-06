using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class CityService : GenericEntityService<City, CityGetDto, CityCreateDto>, ICityService
{
    private readonly ICityRepository _cityRepository;
    protected override string EntityName => "Location";
    
    public CityService(ICityRepository cityRepository) : base(cityRepository)
    {
        _cityRepository = cityRepository;
    }

    protected override CityGetDto MapToGetDto(City city)
    {
        return new CityGetDto
        {
            Id = city.Id,
            Name = city.Name,
            Country = city.Country,
            CountryId = city.CountryId,
        };
    }
    
    protected override City MapToEntityForCreate(CityCreateDto cityCreateDto)
    {
        return new City
        {
            Name = cityCreateDto.Name,
            CountryId = cityCreateDto.CountryId,       
        };   
    }

    protected override City MapToEntityForUpdate(CityCreateDto cityCreateDto, int id)
    {
        return new City
        {
            Id = id,
            Name = cityCreateDto.Name,
            CountryId = cityCreateDto.CountryId,       
        };
    }
}