using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Abstractions;

public interface ITicketTypeService : IEntityService<TicketTypeGetDto, TicketTypeCreateDto>
{
    
}