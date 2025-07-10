using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IBookingService
{
    Task<IEnumerable<BookingUserHistoryDto>> GetBookingUserHistoryAsync(int userId);
    Task CreateBookingAsync(BookingCreateDto bookingCreateDto);
    // nefolosite
    Task<IEnumerable<BookingGetDto>> GetBookingsAsync();
    Task<IEnumerable<BookingFestivalAdminDto>> GetBookingFestivalAdminAsync(int festivalId);
    /* neimplementate
    Task UpdateBookingAsync(BookingCreateDto bookingCreateDto);
    Task DeleteBookingAsync(int festivalId, int userId);*/
}