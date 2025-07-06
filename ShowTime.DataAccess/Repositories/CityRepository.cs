using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    private readonly DbSet<City> _cities;
    
    public CityRepository(ShowTimeDbContext context) : base(context)
    {
        _cities = context.Set<City>();
    }
}