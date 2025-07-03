using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

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

    public async Task<IEnumerable<Artist>> FilterByGenre(int genreId)
    {
        return await _artists
            .Where(a => a.GenreId == genreId)
            .ToListAsync();       
    }

    public async Task<IEnumerable<Artist>> SearchByName(string name)
    {
        return await _artists
            .Where(a => a.Name.Contains(name))
            .ToListAsync();       
    }
}