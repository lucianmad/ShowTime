using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories;

public class FestivalTicketTypeRepository : IFestivalTicketTypeRepository
{
    private readonly ShowTimeDbContext _context;
    private readonly DbSet<FestivalTicketType> _festivalTicketTypes;

    public FestivalTicketTypeRepository(ShowTimeDbContext context)
    {
        _context = context;
        _festivalTicketTypes = context.Set<FestivalTicketType>();
    }

    public async Task<FestivalTicketType?> GetAsync(int festivalId, int ticketTypeId)
    {
        try
        {
            return await _festivalTicketTypes.SingleOrDefaultAsync(ftt => ftt.FestivalId == festivalId && ftt.TicketTypeId == ticketTypeId);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to get festival ticket type: {ex.Message}");
        }
    }

    public async Task<IEnumerable<FestivalTicketType>> GetByFestivalIdAsync(int festivalId)
    {
        return await _festivalTicketTypes
            .Include(ftt => ftt.TicketType)
            .Where(ftt => ftt.FestivalId == festivalId)
            .ToListAsync();   
    }

    public async Task<IEnumerable<FestivalTicketType>> GetByTicketTypeIdAsync(int ticketTypeId)
    {
        return await _festivalTicketTypes
            .Include(ftt => ftt.Festival)
            .Where(ftt => ftt.TicketTypeId == ticketTypeId)
            .ToListAsync();  
    }

    public async Task AddAsync(FestivalTicketType festivalTicketType)
    {
        try
        {
            await _festivalTicketTypes.AddAsync(festivalTicketType);
            await _context.SaveChangesAsync();       
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to add festival ticket type: {ex.Message}");
        }
    }

    public async Task UpdateAsync(FestivalTicketType festivalTicketType)
    {
        try
        {
            var existingEntity = await _festivalTicketTypes.FindAsync(festivalTicketType.FestivalId, festivalTicketType.TicketTypeId);
            if (existingEntity == null)
            {
                throw new Exception($"Festival ticket type with festivalId {festivalTicketType.FestivalId} and ticketTypeId {festivalTicketType.TicketTypeId} not found.");
            }
            
            existingEntity.Price = festivalTicketType.Price;
            
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to update festival ticket type: {ex.Message}");
        }
    }

    public async Task DeleteAsync(int festivalId, int ticketTypeId)
    {
        try
        {
            var entity = await _festivalTicketTypes.FindAsync(festivalId, ticketTypeId);
            if (entity == null)
            {
                throw new Exception($"Festival ticket type with festivalId {festivalId} and ticketTypeId {ticketTypeId} not found.");
            }
            
            _festivalTicketTypes.Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to delete festival ticket type with festivalId {festivalId} and ticketTypeId {ticketTypeId}: {ex.Message}");      
        }
    }
}