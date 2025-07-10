using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class TicketTypeService : GenericEntityService<TicketType, TicketTypeGetDto, TicketTypeCreateDto>, ITicketTypeService
{
    private readonly ITicketTypeRepository _repository;

    protected override string EntityName => "TicketType";
    
    public TicketTypeService(ITicketTypeRepository ticketTypeRepository) : base(ticketTypeRepository)
    {
        _repository = ticketTypeRepository;
    }

    protected override TicketTypeGetDto MapToGetDto(TicketType ticketType)
    {
        return new TicketTypeGetDto
        {
            Id = ticketType.Id,
            Name = ticketType.Name
        };
    }

    protected override TicketType MapToEntityForCreate(TicketTypeCreateDto dto)
    {
        return new TicketType
        {
            Name = dto.Name
        };
    }

    protected override TicketType MapToEntityForUpdate(TicketTypeCreateDto dto, int id)
    {
        return new TicketType
        {
            Id = id,
            Name = dto.Name
        };
    }
}