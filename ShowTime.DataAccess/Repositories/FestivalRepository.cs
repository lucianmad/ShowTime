using ShowTime.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories;

public class FestivalRepository : GenericRepository<Festival>, IFestivalRepository
{
    private readonly DbSet<Festival> _festivals;
    
    public FestivalRepository(ShowTimeDbContext context) : base(context)
    {
        _festivals = context.Set<Festival>();
    }

    public async Task<Festival?> GetByName(string name)
    {
        try
        {
            return await _festivals.SingleOrDefaultAsync(f => f.Name == name);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve festival with name {name}: {ex.Message}");
        }
    }
    
    public async Task<IEnumerable<Festival>> FilterByDate(DateTime date)
    {
        return await _festivals.Where(f => f.StartDate >= date && date <= f.EndDate).ToListAsync();
    }
    
    public async Task<IEnumerable<Festival>> FilterByLocation(int locationId)
    {
        return await _festivals
            .Where(f => f.LocationId == locationId)
            .ToListAsync();       
    }

    public async Task<IEnumerable<Festival>> SearchByName(string name)
    {
        return await _festivals
            .Where(f => f.Name.Contains(name))
            .ToListAsync();       
    }
}