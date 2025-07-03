using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IFestivalService : IEntityService<FestivalGetDto, FestivalCreateDto>
{
}