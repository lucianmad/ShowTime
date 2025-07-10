using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class FestivalTicketTypeService : IFestivalTicketTypeService
{
    private readonly IFestivalTicketTypeRepository _festivalTicketTypeRepository;
    private readonly IFestivalRepository _festivalRepository;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly IBookingRepository _bookingRepository;

    public FestivalTicketTypeService(
        IFestivalTicketTypeRepository festivalTicketTypeRepository,
        IFestivalRepository festivalRepository,
        ITicketTypeRepository ticketTypeRepository,
        IBookingRepository bookingRepository)
    {
        _festivalTicketTypeRepository = festivalTicketTypeRepository;
        _festivalRepository = festivalRepository;
        _ticketTypeRepository = ticketTypeRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task AddFestivalTicketTypeAsync(FestivalTicketTypeCreateDto festivalTicketTypeCreateDto)
    {
        await ValidateInputAsync(festivalTicketTypeCreateDto);
        var festivalTicketType = new FestivalTicketType
        {
            FestivalId = festivalTicketTypeCreateDto.FestivalId,
            TicketTypeId = festivalTicketTypeCreateDto.TicketTypeId,
            Price = festivalTicketTypeCreateDto.Price,
            Quantity = festivalTicketTypeCreateDto.Quantity
        };
        try
        {
            await _festivalTicketTypeRepository.AddAsync(festivalTicketType);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to add ticket type to festival: {ex.Message}");       
        }
    }

    public async Task UpdateFestivalTicketTypeAsync(FestivalTicketTypeCreateDto festivalTicketTypeCreateDto)
    {
        await ValidateInputAsync(festivalTicketTypeCreateDto);
        try
        {
            var festivalTicketType = new FestivalTicketType
            {
                FestivalId = festivalTicketTypeCreateDto.FestivalId,
                TicketTypeId = festivalTicketTypeCreateDto.TicketTypeId,
                Price = festivalTicketTypeCreateDto.Price,
                Quantity = festivalTicketTypeCreateDto.Quantity
            };

            await _festivalTicketTypeRepository.UpdateAsync(festivalTicketType);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to update ticket type to festival: {ex.Message}");      
        }
    }

    public async Task<IEnumerable<FestivalTicketTypeForPurchaseDto>> GetAvailableFestivalTicketTypesAsync(int festivalId)
    {
        var festivalTicketTypes = await _festivalTicketTypeRepository.GetByFestivalIdAsync(festivalId);
        var festivalBookings = await _bookingRepository.GetByFestivalIdAsync(festivalId);
    
        return festivalTicketTypes.Select(ftt =>
        {
            var bookedCount = festivalBookings.Count(b => b.TicketTypeId == ftt.TicketTypeId);
            var availableQuantity = ftt.Quantity - bookedCount;
        
            return new FestivalTicketTypeForPurchaseDto
            {
                TicketTypeId = ftt.TicketTypeId,
                TicketTypeName = ftt.TicketType.Name ?? string.Empty,
                TicketTypeDescription = ftt.TicketType?.Description,
                Price = ftt.Price,
                AvailableQuantity = availableQuantity
            };
        }).Where(dto => dto.AvailableQuantity > 0);;
    }

    public async Task<IEnumerable<FestivalTicketTypeAdminDto>> GetFestivalTicketTypesForAdminAsync(int festivalId)
    {
        var festivalTicketTypes = await _festivalTicketTypeRepository.GetByFestivalIdAsync(festivalId);
        var festivalBookings = await _bookingRepository.GetByFestivalIdAsync(festivalId);
    
        return festivalTicketTypes.Select(ftt =>
        {
            var bookedCount = festivalBookings.Count(b => b.TicketTypeId == ftt.TicketTypeId);
        
            return new FestivalTicketTypeAdminDto
            {
                TicketTypeId = ftt.TicketTypeId,
                TicketTypeName = ftt.TicketType.Name ?? string.Empty,
                TicketTypeDescription = ftt.TicketType?.Description,
                Price = ftt.Price,
                Quantity = ftt.Quantity,
                BookedQuantity = bookedCount,                    
                RemainingQuantity = ftt.Quantity - bookedCount  
            };
        });
    }

    public async Task RemoveFromFestivalTicketTypeAsync(int festivalId, int ticketTypeId)
    {
        await _festivalTicketTypeRepository.DeleteAsync(festivalId, ticketTypeId);
    }
    
    public async Task AddMultipleFestivalTicketTypesAsync(int festivalId, IEnumerable<FestivalTicketTypeCreateDto> ticketTypes)
    {
        foreach (var ticketType in ticketTypes)
        {
            ticketType.FestivalId = festivalId;
            await AddFestivalTicketTypeAsync(ticketType);
        }
    }
    
    private async Task ValidateInputAsync(FestivalTicketTypeCreateDto festivalTicketTypeCreateDto)
    {
        if (festivalTicketTypeCreateDto.FestivalId <= 0)
             throw new ArgumentException("Invalid FestivalId");

        if (festivalTicketTypeCreateDto.TicketTypeId <= 0)
            throw new ArgumentException("Invalid TicketTypeId");

        if (festivalTicketTypeCreateDto.Price < 0)
            throw new ArgumentException("Price cannot be negative");
        
        if (festivalTicketTypeCreateDto.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0");

        var festival = await _festivalRepository.GetByIdAsync(festivalTicketTypeCreateDto.FestivalId);
        if (festival == null)
             throw new ArgumentException($"Festival with ID {festivalTicketTypeCreateDto.FestivalId} not found");

        var ticketType = await _ticketTypeRepository.GetByIdAsync(festivalTicketTypeCreateDto.TicketTypeId);
        if (ticketType == null)
            throw new ArgumentException($"TicketType with ID {festivalTicketTypeCreateDto.TicketTypeId} not found");
    }
}
