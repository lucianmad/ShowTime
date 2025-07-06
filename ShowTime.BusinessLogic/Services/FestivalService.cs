using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class FestivalService : GenericEntityService<Festival, FestivalGetDto, FestivalCreateDto>, IFestivalService
{
    private readonly IFestivalRepository _festivalRepository;
    protected override string EntityName => "Festival";
    
    public FestivalService(IFestivalRepository festivalRepository) : base(festivalRepository)
    {
        _festivalRepository = festivalRepository;   
    }

    protected override FestivalGetDto MapToGetDto(Festival festival)
    {
        return new FestivalGetDto
        {
            Id = festival.Id,
            Name = festival.Name,
            City = festival.City,
            CityId = festival.CityId,
            StartDate = festival.StartDate,
            EndDate = festival.EndDate,
            SplashArt = festival.SplashArt,
            Capacity = festival.Capacity
        };
    }

    protected override Festival MapToEntityForCreate(FestivalCreateDto festivalCreateDto)
    {
        return new Festival
        {
            Name = festivalCreateDto.Name,
            CityId = festivalCreateDto.CityId,
            StartDate = festivalCreateDto.StartDate,
            EndDate = festivalCreateDto.EndDate,
            SplashArt = festivalCreateDto.SplashArt,
            Capacity = festivalCreateDto.Capacity
        };   
    }

    protected override Festival MapToEntityForUpdate(FestivalCreateDto festivalCreateDto, int id)
    {
        return new Festival
        {
            Id = id,
            Name = festivalCreateDto.Name,
            CityId = festivalCreateDto.CityId,
            StartDate = festivalCreateDto.StartDate,
            EndDate = festivalCreateDto.EndDate,
            SplashArt = festivalCreateDto.SplashArt,
            Capacity = festivalCreateDto.Capacity
        };
    }

    public async Task<List<FestivalGetDto>> FilterByCityAsync(int cityId)
    {
        var festivals = await _festivalRepository.FilterByCity(cityId);
        return festivals.Select(MapToGetDto).ToList();  
    }
    
    public async Task<List<FestivalGetDto>> FilterByDateAsync(DateTime date)
    {
        var festivals = await _festivalRepository.FilterByDate(date);
        return festivals.Select(MapToGetDto).ToList(); 
    }
    
    public async Task<List<FestivalGetDto>> FilterByCountryAsync(int countryId)
    {
        var festivals = await _festivalRepository.FilterByCountry(countryId);
        return festivals.Select(MapToGetDto).ToList(); 
    }
    
    public async Task<List<FestivalGetDto>> SearchByNameAsync(string name)
    {
        var festivals = await _festivalRepository.SearchByName(name);
        return festivals.Select(MapToGetDto).ToList();  
    }
    
}