using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ShowTimeDbContext _context;
    private readonly DbSet<Booking> _bookings;
    
    public BookingRepository(ShowTimeDbContext context)
    {
        _context = context;
        _bookings = _context.Set<Booking>();
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _bookings
            .Include(b => b.User)
            .Include(b => b.Festival)
            .Include(b => b.FestivalTicketType)
                .ThenInclude(ftt => ftt.TicketType)
            .ToListAsync();
    }

    public async Task<Booking?> GetAsync(int userId, int festivalId, int ticketTypeId)
    {
        try
        {
            return await _bookings
                .Include(b => b.FestivalTicketType)
                    .ThenInclude(ftt => ftt.TicketType)
                .Include(b => b.User)
                .Include(b => b.Festival)
                .SingleOrDefaultAsync(b => b.FestivalId == festivalId && b.UserId == userId && b.TicketTypeId == ticketTypeId);
        }
        catch (Exception ex)   
        {
            throw new Exception($"Unable to get booking: {ex.Message}");
        }   
    }

    public async Task<IEnumerable<Booking>> GetByFestivalIdAsync(int festivalId)
    {
        return await _bookings
            .Include(b => b.User)
            .Include(b => b.FestivalTicketType)
                .ThenInclude(ftt => ftt.TicketType)
            .Where(b => b.FestivalId == festivalId)
            .ToListAsync();   
    }

    public async Task<IEnumerable<Booking>> GetByUserIdAsync(int userId)
    {
        return await _bookings
            .Include(b => b.Festival)
            .Include(b => b.FestivalTicketType)
                .ThenInclude(ftt => ftt.TicketType)
            .Where(b => b.UserId == userId)
            .ToListAsync();   
    }

    public async Task AddAsync(Booking booking)
    {
        try
        {
            await _bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to add booking: {ex.Message}");       
        }
    }
    
    public async Task UpdateAsync(Booking booking)
    {
        try
        {
            var existingEntity = await _bookings.FindAsync(booking.FestivalId, booking.UserId);
            if (existingEntity == null)
            {
                throw new Exception($"Booking with festivalId {booking.FestivalId} and userId {booking.UserId} not found.");
            }

            existingEntity.TicketTypeId = booking.TicketTypeId;
            
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to update booking: {ex.Message}");       
        }
    }

    public async Task DeleteAsync(int festivalId, int userId)
    {
        try
        {
            var entity = await _bookings.FindAsync(festivalId, userId);
            if (entity == null)
            {
                throw new Exception($"Booking with festivalId {festivalId} and userId {userId} not found.");
            }
            _bookings.Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to delete booking with festivalId {festivalId} and userId {userId}: {ex.Message}");      
        }
    }
    
    public async Task<int> GetBookedCountAsync(int festivalId, int ticketTypeId)
    {
        try
        {
            return await _bookings
                .CountAsync(b => b.FestivalId == festivalId && b.TicketTypeId == ticketTypeId);
        }
        catch (Exception ex)   
        {
            throw new Exception($"Unable to get booked count: {ex.Message}");
        }   
    }
}