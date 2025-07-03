using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories;

public class LocationRepository : GenericRepository<Location>, ILocationRepository
{
    private readonly DbSet<Location> _locations;
    
    public LocationRepository(ShowTimeDbContext context) : base(context)
    {
        _locations = context.Set<Location>();
    }
}