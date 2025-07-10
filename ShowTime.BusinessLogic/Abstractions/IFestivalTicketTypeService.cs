using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IFestivalTicketTypeService
{
    Task<IEnumerable<FestivalTicketTypeForPurchaseDto>> GetAvailableFestivalTicketTypesAsync(int festivalId);
    Task AddMultipleFestivalTicketTypesAsync(int festivalId, IEnumerable<FestivalTicketTypeCreateDto> ticketTypes);
    // nefolosite
    Task AddFestivalTicketTypeAsync(FestivalTicketTypeCreateDto festivalTicketTypeCreateDto);
    Task UpdateFestivalTicketTypeAsync(FestivalTicketTypeCreateDto festivalTicketTypeCreateDto);
    Task<IEnumerable<FestivalTicketTypeAdminDto>> GetFestivalTicketTypesForAdminAsync(int festivalId);
    Task RemoveFromFestivalTicketTypeAsync(int festivalId, int ticketTypeId);
}