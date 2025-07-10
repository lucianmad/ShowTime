using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions;

public interface IFestivalTicketTypeRepository
{
    Task AddAsync(FestivalTicketType festivalTicketType);
    Task UpdateAsync(FestivalTicketType festivalTicketType);
    Task DeleteAsync(int festivalId, int ticketTypeId);
    Task<FestivalTicketType?> GetAsync(int festivalId, int ticketTypeId);
    Task<IEnumerable<FestivalTicketType>> GetByFestivalIdAsync(int festivalId);
    Task<IEnumerable<FestivalTicketType>> GetByTicketTypeIdAsync(int ticketTypeId);
}