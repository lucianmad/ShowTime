using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories;

public class TicketTypeRepository : GenericRepository<TicketType>, ITicketTypeRepository
{
    private readonly DbSet<TicketType> _ticketTypes;

    public TicketTypeRepository(ShowTimeDbContext context) : base(context)
    {
        _ticketTypes = context.Set<TicketType>();   
    }
}