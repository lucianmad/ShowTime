using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class LocationService : GenericEntityService<Location, LocationGetDto, LocationCreateDto>, ILocationService
{
    private readonly ILocationRepository _locationRepository;
    protected override string EntityName => "Location";
    
    public LocationService(ILocationRepository locationRepository) : base(locationRepository)
    {
        _locationRepository = locationRepository;
    }

    protected override LocationGetDto MapToGetDto(Location location)
    {
        return new LocationGetDto
        {
            Id = location.Id,
            Country = location.Country,
            City = location.City
        };
    }
    
    protected override Location MapToEntityForCreate(LocationCreateDto locationCreateDto)
    {
        return new Location
        {
            Country = locationCreateDto.Country,
            City = locationCreateDto.City
        };   
    }

    protected override Location MapToEntityForUpdate(LocationCreateDto locationCreateDto, int id)
    {
        return new Location
        {
            Id = id,
            Country = locationCreateDto.Country,
            City = locationCreateDto.City
        };
    }
}