using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(int festivalId, int userId);
    Task<Booking?> GetAsync(int userId, int festivalId, int ticketTypeId);
    Task<IEnumerable<Booking>> GetByFestivalIdAsync(int festivalId);
    Task<IEnumerable<Booking>> GetByUserIdAsync(int userId);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<int> GetBookedCountAsync(int festivalId, int userId);
}