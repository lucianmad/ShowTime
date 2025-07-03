using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;

namespace ShowTime.BusinessLogic.Services;

public class FestivalService : GenericEntityService<Festival, FestivalGetDto, FestivalCreateDto>, IFestivalService
{
    protected override string EntityName => "Festival";
    
    public FestivalService(IRepository<Festival> festivalRepository) : base(festivalRepository)
    {
    }

    protected override FestivalGetDto MapToGetDto(Festival festival)
    {
        return new FestivalGetDto
        {
            Id = festival.Id,
            Name = festival.Name,
            Location = festival.Location,
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
            Location = festivalCreateDto.Location,
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
            Location = festivalCreateDto.Location,
            StartDate = festivalCreateDto.StartDate,
            EndDate = festivalCreateDto.EndDate,
            SplashArt = festivalCreateDto.SplashArt,
            Capacity = festivalCreateDto.Capacity
        };
    }
}