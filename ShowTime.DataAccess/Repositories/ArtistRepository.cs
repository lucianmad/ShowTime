using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories;

public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
{
    private readonly DbSet<Artist> _artists;
    
    public ArtistRepository(ShowTimeDbContext context) : base(context)
    {
        _artists = context.Set<Artist>();
    }
    
    public async Task<Artist?> GetByName(string name)
    {
        try
        {
            return await _artists.SingleOrDefaultAsync(a => a.Name == name);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve artist with name {name}: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Artist>> GetAllByGenre(string genre)
    {
        return await _artists.Where(a => a.Genre == genre).ToListAsync();
    }
}