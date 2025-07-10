using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IFestivalTicketTypeRepository _festivalTicketTypeRepository;
    private readonly IUserRepository _userRepository;

    public BookingService(IBookingRepository bookingRepository,
        IFestivalTicketTypeRepository festivalTicketTypeRepository, IUserRepository userRepository)
    {
        _bookingRepository = bookingRepository;
        _festivalTicketTypeRepository = festivalTicketTypeRepository;
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<BookingUserHistoryDto>> GetBookingUserHistoryAsync(int userId)
    {
        var bookings = await _bookingRepository.GetByUserIdAsync(userId);

        return bookings.Select(b => new BookingUserHistoryDto
        {
            FestivalId = b.FestivalId,
            FestivalName = b.Festival.Name,
            Price = b.FestivalTicketType.Price,
            TicketTypeName = b.FestivalTicketType.TicketType.Name
        });
    }

    //neimplementat in pagina
    public async Task<IEnumerable<BookingFestivalAdminDto>> GetBookingFestivalAdminAsync(int festivalId)
    {
        var bookings = await _bookingRepository.GetByFestivalIdAsync(festivalId);

        return bookings.Select(b => new BookingFestivalAdminDto
        {
            UserId = b.UserId,
            UserEmail = b.User.Email,
            Price = b.FestivalTicketType.Price,
            TicketTypeName = b.FestivalTicketType.TicketType.Name
        });
    }

    //neimplementat in pagina
    public async Task<IEnumerable<BookingGetDto>> GetBookingsAsync()
    {
        var bookings = await _bookingRepository.GetAllAsync();

        return bookings.Select(b => new BookingGetDto
        {
            FestivalId = b.FestivalId,
            FestivalName = b.Festival.Name,
            UserId = b.UserId,
            UserEmail = b.User.Email,
            TicketTypeName = b.FestivalTicketType.TicketType.Name,
            Price = b.FestivalTicketType.Price,
        });
    }

    public async Task CreateBookingAsync(BookingCreateDto bookingCreateDto)
    {
        await ValidateBookingAsync(bookingCreateDto);
        var booking = new Booking
        {
            UserId = bookingCreateDto.UserId,
            FestivalId = bookingCreateDto.FestivalId,
            TicketTypeId = bookingCreateDto.TicketTypeId,
        };
        
        await _bookingRepository.AddAsync(booking);
    }
    
    private async Task ValidateBookingAsync(BookingCreateDto bookingCreateDto)
    {
        if (bookingCreateDto.FestivalId <= 0)
            throw new ArgumentException("Invalid FestivalId");

        if (bookingCreateDto.TicketTypeId <= 0)
            throw new ArgumentException("Invalid TicketTypeId");

        if (bookingCreateDto.UserId <= 0)
            throw new ArgumentException("Invalid UserId");

        var user = await _userRepository.GetByIdAsync(bookingCreateDto.UserId);
        if (user == null)
            throw new ArgumentException($"User with ID {bookingCreateDto.UserId} not found");

        var festivalTicketType = await _festivalTicketTypeRepository.GetAsync(
            bookingCreateDto.FestivalId,
            bookingCreateDto.TicketTypeId);

        if (festivalTicketType == null)
            throw new Exception("Invalid combination of ticket type and festival");

        var existingBooking = await _bookingRepository.GetAsync(
            bookingCreateDto.UserId,
            bookingCreateDto.FestivalId,
            bookingCreateDto.TicketTypeId);

        if (existingBooking != null)
            throw new Exception("Booking already exists");

        var bookedCount = await _bookingRepository.GetBookedCountAsync(
            bookingCreateDto.FestivalId,
            bookingCreateDto.TicketTypeId);

        if (bookedCount >= festivalTicketType.Quantity)
            throw new Exception("No more tickets available for this type");
    }

    
    
}